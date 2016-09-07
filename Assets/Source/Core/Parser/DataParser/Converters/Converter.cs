using System;
using System.Collections.Generic;
using Assets.Source.Core.Parser.DataParser.Types;
using UnityEngine;

namespace Assets.Source.Core.Parser.DataParser.Converters
{
    public abstract class Converter
    {
        private static IDictionary<Type, Converter> ConverterByType { get; set; }

        protected abstract Type Type { get; }

        protected abstract object InvalidValue { get; }

        protected Converter()
        {
            if(ConverterByType == null)
                ConverterByType = new Dictionary<Type, Converter>();

            ConverterByType[Type] = this;
        }

        public abstract object Convert(IParserType type);

        public abstract bool IsValueInvalid(object value);

        public static Converter GetConverter(Type type)
        {
            try
            {
                var converter = ConverterByType[type];
                return converter;
            }
            catch
            {
                return null;
            }
        }
    }
}