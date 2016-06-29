using System;

namespace Assets.Source.Core.Parser.DataParser.Attributes
{
    public class DefaultValue : Attribute
    {
        public object Value;

        public DefaultValue(object value)
        {
            this.Value = value;
        }
    }
}