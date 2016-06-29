using System.Collections.Generic;

namespace Assets.Source.Core.Parser.DataParser.Types
{
	public class ParserObject : IParserType, IParserContainingType
	{
		#region Properties
		public const string PARSER_OBJECT = "PARSER_OBJECT";

		private IParserContainingType _parent = null;

		private Dictionary<string, IParserType> _hashTable;
		public Dictionary<string, IParserType> HashTable
		{
			get { return _hashTable; }
		}

		private string _key = "";
		private string _value = "";
		private bool _isQuoted = false;
		private bool _isCommented = false;
		#endregion

		#region Constructors
		public ParserObject()
		{
			_hashTable = new Dictionary<string, IParserType>();
		}
		#endregion

		#region Methods
		#region IParserContainingType Implementations
		public bool AddChild(string key, IParserType parserType)
		{
			_hashTable[key] = parserType;
			return true;
		}
		public bool RemoveChild(IParserType parserType)
		{
			foreach (var keyValue in _hashTable) {
				if (keyValue.Value == parserType) {
					_hashTable.Remove(keyValue.Key);
					return true;
				}
			}
			return false;
		}
		#endregion

		#region IParserType Implementations
		public new string GetType()
		{
			return PARSER_OBJECT;
		}

		public bool SetParent(string key, IParserContainingType parserContainingType)
		{
			if (_parent == parserContainingType) {
				return true;
			} else {
				if(_parent != null) _parent.RemoveChild(this);
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
		    switch (character)
		    {
		        case '}':
		            return (IParserType)GetParent();
		        case '{':
		            var obj = new ParserObject();
		            obj.SetParent(_key, this);
		            _key = "";
		            return obj;
		        case '[':
		            var arr = new ParserArray();
		            arr.SetParent(_key, this);
		            _key = "";
		            return arr;
		        case '=':
		            _key = _value;
		            _value = "";
		            break;
		        case ' ':
		            if(_isQuoted) {
		                _value += character;
		            }
		            break;
		        case '"':
		            _isQuoted = !_isQuoted;
		            break;
		        case '#':
		            _isCommented = true;
		            break;
		        case '\n':
		            _isCommented = false;
		            break;
		        default:
		            if (!_isCommented){
		                if (_key != "") {
		                    var val = new ParserValue();
		                    val.SetParent(_key, this);
		                    _key = "";
		                    return val.HandleCharacter(character);
		                } else {
		                    _value += character;
		                }
		            }
		            break;
		    }
		    return this;
		}

	    #endregion
		#endregion
	}
}
