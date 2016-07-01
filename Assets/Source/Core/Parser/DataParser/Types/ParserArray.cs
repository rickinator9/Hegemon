using System.Collections.Generic;

namespace Assets.Source.Core.Parser.DataParser.Types
{
	class ParserArray : IParserType, IParserContainingType
	{
		#region Properties
		public const string PARSER_ARRAY = "PARSER_ARRAY";

        public IParserType[] Values { get { return _types.ToArray(); } }

		private readonly List<IParserType> _types;

		private IParserContainingType _parent = null;

		private bool _isCommented = false;
		#endregion

		#region Constructors
		public ParserArray()
		{
			_types = new List<IParserType>();
		}
		#endregion

		#region Methods
		#region IParserContainingType Implementation
		public bool AddChild(string key, IParserType parserType)
		{
			_types.Add(parserType);
			return true;
		}

		public bool RemoveChild(IParserType parserType)
		{
			return _types.Remove(parserType);
		}
		#endregion

		#region IParserType Implementation
		public new string GetType()
		{
			return PARSER_ARRAY;
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
			if (character == ']') {
				return (IParserType)GetParent();
			} else if (character == '#') {
				_isCommented = true;
			} else if (character == '\n') {
				_isCommented = false;
			} else if (character != ' ' && !_isCommented) {
				var val = new ParserValue();
				val.SetParent("", this);
				val.HandleCharacter(character);
				return val;
			}
			return this;
		}
		#endregion
		#endregion
	}
}
