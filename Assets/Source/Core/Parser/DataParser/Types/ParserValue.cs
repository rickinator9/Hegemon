namespace Assets.Source.Core.Parser.DataParser.Types
{
	public class ParserValue : IParserType
	{
		#region Properties
		public const string PARSER_VALUE = "PARSER_VALUE";

		private IParserContainingType _parent = null;
        
		public string Value { get; set; }

		private bool _isQuoted = false;
		#endregion

		#region Constructors
		public ParserValue()
		{

		}
		#endregion

		#region Methods
		#region IParserType Implementation
		public new string GetType()
		{
			return PARSER_VALUE;
		}

		public bool SetParent(string key, IParserContainingType parserContainingType)
		{
			if (_parent == parserContainingType) { 
				return true; 
			} else {
				if (_parent != null) _parent.RemoveChild(this);
				if (parserContainingType.AddChild(key, this)) {
					_parent = parserContainingType;
					return true;
				} else {
					_parent = null;
					return false;
				}
			}
		}
		public IParserContainingType GetParent()
		{
			return _parent;
		}

		public IParserType HandleCharacter(char character)
		{
			if (character == '"') {
				if (_isQuoted) {
					_isQuoted = false;
					return (IParserType)GetParent();
				} else {
					_isQuoted = true;
				}
			} else if (character == '\n') {
				return (IParserType)GetParent();
			} else if (character == '#') {
				return ((IParserType)GetParent()).HandleCharacter(character);
			} else if (character == ' ' && Value != "") {
				if (_isQuoted) {
					Value += character;
				} else {
					return (IParserType)GetParent();
				}
			} else {
				Value += character;
			}
			return this;
		}
		#endregion
		#endregion
	}
}
