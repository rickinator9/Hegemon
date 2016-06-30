using System;
using Assets.Source.Core.Parser.DataParser.Types;
using UnityEngine;

namespace Assets.Source.Core.Parser.DataParser.Converters
{
    public class Vector2Converter : Converter
    {
        protected override Type Type
        {
            get { return typeof (Vector2); }
        }

        protected override object InvalidValue
        {
            get { return Vector2.zero; }
        }

        public override object Convert(IParserType type)
        {
            var parserObject = type as ParserObject;
            var parserArray = type as ParserArray;

            float x = 0f, y = 0f;
            if (parserObject != null)
            {
                if(!(parserObject.HashTable.ContainsKey("x") || parserObject.HashTable.ContainsKey("y")))
                    return InvalidValue;
                var xVal = parserObject.HashTable["x"];
                var yVal = parserObject.HashTable["y"];

                if (!(xVal is ParserValue && yVal is ParserValue)) return InvalidValue;
                var xStr = (xVal as ParserValue).Value;
                var yStr = (yVal as ParserValue).Value;

                if(!(float.TryParse(xStr, out x) || float.TryParse(yStr, out y))) return InvalidValue;
            } else if (parserArray != null)
            {
                //TODO: Impl parserarray
            }
            else return InvalidValue;

            return new Vector2(x, y);
        }

        public override bool IsValueInvalid(object value)
        {
            throw new NotImplementedException();
        }
    }
}