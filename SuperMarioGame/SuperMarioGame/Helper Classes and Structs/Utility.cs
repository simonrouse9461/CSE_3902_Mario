using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace SuperMario
{
    public static class Utility
    {
        private static object Clone(object source)
        {
            var sourceType = source.GetType();
            var target = FormatterServices.GetUninitializedObject(sourceType);
            var fieldList = sourceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fieldList)
            {
                var fieldType = field.FieldType;
                var fieldValue = field.GetValue(source);
                var passByValue = fieldType.IsValueType
                                  || fieldType.IsEnum
                                  || fieldType.IsArray
                                  || fieldType == typeof (string)
                                  || fieldValue == null
                                  || fieldValue == source;
                field.SetValue(target, passByValue ? fieldValue : Clone(fieldValue));
            }
            return target;
        }

        public static T DeepClone<T>(T source) where T : class
        {
            return (T) Clone(source);
        }
    }
}