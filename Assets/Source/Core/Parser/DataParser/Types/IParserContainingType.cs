

namespace Assets.Source.Core.Parser.DataParser.Types
{
	public interface IParserContainingType
	{
		#region Properties
		#endregion

		#region Methods
		bool AddChild(string key, IParserType parserType);
		bool RemoveChild(IParserType parserType);
		#endregion
	}
}
