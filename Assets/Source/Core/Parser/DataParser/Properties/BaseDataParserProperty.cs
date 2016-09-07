using System.Reflection;
using Assets.Source.Core.Parser.DataParser.Attributes;
using Assets.Source.Core.Parser.DataParser.Converters;
using Assets.Source.Core.Parser.DataParser.Types;
using strange.extensions.injector.api;
using UnityEngine;

namespace Assets.Source.Core.Parser.DataParser.Properties
{
    public abstract class BaseDataParserProperty<T> : IDataParserProperty<T>
    {
        protected string _id;

        public void LoadParserObject(string identifier, ParserObject parserObject)
        {
            _id = identifier;

            TryProcessProperties(parserObject);
        }

        protected void TryProcessProperties(ParserObject parserObject)
        {
            var properties = GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (ObjectHasProperty(parserObject, property))
                {
                    var parserType = parserObject.HashTable[property.Name];

                    var propertyType = property.PropertyType;
                    var converter = Converter.GetConverter(propertyType);
                    if (converter == null)
                        continue;

                    var value = converter.Convert(parserType);
                    if (converter.IsValueInvalid(value))
                    {
                        if (PropertyHasDefaultValue(property))
                        {
                            var potentialDefaultValues = property.GetCustomAttributes(typeof(DefaultValue), false);
                            var defaultValue = potentialDefaultValues[0] as DefaultValue;
                            value = defaultValue.Value;
                        }
                        else
                            continue;
                    }

                    property.SetValue(this, value, null);
                }
            }
        }

        protected bool PropertyHasDefaultValue(PropertyInfo property)
        {
            var potentialDefaultValues = property.GetCustomAttributes(typeof(DefaultValue), false);
            return potentialDefaultValues.Length > 0;
        }

        protected bool ObjectHasProperty(ParserObject parserObject, PropertyInfo property)
        {
            var propertyName = property.Name;
            return parserObject.HashTable.ContainsKey(propertyName);
        }

        public abstract T PopulateModel(IInjectionBinder injectionBinder);
    }
}