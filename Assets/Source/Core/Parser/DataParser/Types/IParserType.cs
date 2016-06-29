

namespace Assets.Source.Core.Parser.DataParser.Types
{
	public interface IParserType
	{
		#region Properties
		#endregion

		#region Methods
		string GetType();

		bool SetParent(string key, IParserContainingType parserContainingType);
		IParserContainingType GetParent();

		IParserType HandleCharacter(char character);
		#endregion
	}
}
