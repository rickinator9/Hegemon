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
                if (!(parserObject.HashTable.ContainsKey("x") || parserObject.HashTable.ContainsKey("y")))
                {
                    Debug.Log("x or y could not be found in Vector2 object!");
                    return InvalidValue;
                }
                var xVal = parserObject.HashTable["x"];
                var yVal = parserObject.HashTable["y"];

                if (!(xVal is ParserValue && yVal is ParserValue))
                {
                    Debug.Log("x or y aren't values!");
                    return InvalidValue;
                }
                var xStr = (xVal as ParserValue).Value;
                var yStr = (yVal as ParserValue).Value;

                if (!(float.TryParse(xStr, out x) || float.TryParse(yStr, out y)))
                {
                    Debug.Log("x or y could not be read as a number!");
                    return InvalidValue;
                }
            } else if (parserArray != null)
            {
                var values = parserArray.Values;
                if (values.Length < 2)
                {
                    Debug.Log("Vector2 array has less than 2 children!");
                    return InvalidValue;
                }

                var xVal = values[0];
                var yVal = values[1];
                if (!(xVal is ParserValue && yVal is ParserValue))
                {
                    Debug.Log("Vector2 array children are not values!");
                    return InvalidValue;
                }

                var xStr = (xVal as ParserValue).Value;
                var yStr = (yVal as ParserValue).Value;

                if (!(float.TryParse(xStr, out x) && float.TryParse(yStr, out y)))
                {
                    Debug.Log("Vector2 array values could not be read as numbers!");
                    return InvalidValue;
                }
            }
            else return InvalidValue;

            return new Vector2(x, y);
        }

        public override bool IsValueInvalid(object value)
        {
            return value == InvalidValue;
        }
    }
}