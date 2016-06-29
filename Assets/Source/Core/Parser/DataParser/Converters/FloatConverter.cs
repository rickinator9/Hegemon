using System;
using Assets.Source.Core.Parser.DataParser.Types;

namespace Assets.Source.Core.Parser.DataParser.Converters
{
    public class FloatConverter : Converter
    {
        protected override Type Type
        {
            get { return typeof (float); }
        }

        protected override object InvalidValue
        {
            get { return float.NaN; }
        }

        public FloatConverter() : base()
        {
            
        }

        public override object Convert(IParserType text)
        {
            var parserValue = text as ParserValue;
            if (parserValue == null)
                return InvalidValue;

            try
            {
                var floatValue = float.Parse(parserValue.Value);
                return floatValue;
            }
            catch
            {
                return InvalidValue;
            }
        }

        public override bool IsValueInvalid(object value)
        {
            var fValue = (float) value;
            return float.IsNaN(fValue);
        }
    }
}