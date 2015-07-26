using System;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;

namespace SuperMario
{
    public static class Utility
    {
        public static T DeepClone<T>(T source) where T : class
        {
            var sourceType = source.GetType();
                //sourceType.GetConstructor(Type.EmptyTypes) == null
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
                field.SetValue(target, passByValue ? fieldValue : DeepClone(fieldValue));
            }
            return (T)target;
        }
    }
}