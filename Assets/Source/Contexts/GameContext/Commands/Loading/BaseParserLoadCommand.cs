using Assets.Source.Contexts.GameContext.Signals.Loading;
using Assets.Source.Core.Model;
using Assets.Source.Core.Model.Identifiable;
using Assets.Source.Core.Model.Identifiable.Managers;
using Assets.Source.Core.Parser.DataParser;
using Assets.Source.Core.Parser.DataParser.Properties;
using Assets.Source.Core.Parser.DataParser.Types;
using Assets.Source.Utilities.IoC;
using strange.extensions.command.impl;
using Debug = UnityEngine.Debug;

//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public abstract class BaseParserLoadCommand<TModel, TProperty> : AsyncCommand where TModel : IIdentifiable
                                                                       where TProperty : BaseDataParserProperty<TModel>, new()
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<BaseLoadCommand>();

        #region From signal

        #endregion

        #region Dependencies
        [Inject]
        public BaseIdentifiableManager<TModel> Manager { get; set; } 
        #endregion

        #region Dispatchers
        [Inject]
        public LoadingDoneSignal LoadingDoneDispatcher { get; set; }
        #endregion
        
        /// <summary>
        /// Directory in which the source files are.
        /// </summary>
        protected abstract string Directory { get; }

        /// <summary>
        /// The LoadStatus this loadcommand represents.
        /// </summary>
        protected abstract LoadStatus LoadStatus { get; }

        protected BaseParserLoadCommand()
        {
            Debug.Log("BaseAsyncLoadCommand");
        } 

        protected override void Run()
        {
            var fileParser = new FileParser(Directory);
            var resourceRoot = fileParser.Parse() as ParserObject;
            if (resourceRoot == null)
                return;

            foreach (var pair in resourceRoot.HashTable)
            {
                var identifier = pair.Key;
                var parserObject = pair.Value as ParserObject;
                if (parserObject == null)
                    continue;

                var resourceProperty = new TProperty();
                resourceProperty.LoadParserObject(identifier, parserObject);

                var model = resourceProperty.PopulateModel(injectionBinder);
                Manager.Set(model);
            }
        }

        protected override void OnFinish()
        {
            LoadingDoneDispatcher.Dispatch(LoadStatus);
        }
    }
}