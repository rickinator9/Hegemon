using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Contexts.GameContext.Model.Managers;
using Assets.Source.Core.Model;
using Assets.Source.Core.Parser.DataParser;
using Assets.Source.Core.Parser.DataParser.Properties;
using Assets.Source.Core.Parser.DataParser.Types;
using strange.extensions.command.impl;
//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public abstract class BaseLoadCommand<TModel, TProperty> : Command where TModel : IIdentifiable
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

        #endregion
        
        /// <summary>
        /// Directory in which the source files are.
        /// </summary>
        protected abstract string Directory { get; }

        public override void Execute()
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
                //Resources.Resources.Add(resource);
            }
        }
    }
}