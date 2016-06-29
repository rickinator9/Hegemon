using Assets.Source.Core.Parser.DataParser.Types;
using strange.extensions.injector.api;

namespace Assets.Source.Core.Parser.DataParser.Properties
{
    public interface IDataParserProperty<T>
    {
        void LoadParserObject(string identifier, ParserObject parserObject);

        T PopulateModel(IInjectionBinder injectionBinder);
    }
}