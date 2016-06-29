using System;
using Assets.Source.Core.Parser.DataParser.Types;

namespace Assets.Source.Core.Parser.DataParser.Converters
{
    public class StringConverter : Converter
    {
        protected override Type Type
        {
            get { return typeof (string); }
        }

        protected override object InvalidValue
        {
            get { return ""; }
        }

        public override object Convert(IParserType text)
        {
            var parserValue = text as ParserValue;
            if (parserValue == null)
                return InvalidValue;

            return parserValue.Value;
        }

        public override bool IsValueInvalid(object value)
        {
            return string.IsNullOrEmpty(value as string);
        }
    }
}