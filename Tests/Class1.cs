using System;
using System.Reflection;

namespace Tests
{
    public class IntSome: GenericBaseSome<int>
    {
        
    }
    public class StringSome: GenericBaseSome<int>
    {
        
    }
    public class GenericBaseSome<TProperty>
    {
        private static PropertyInfo k__PropertyInfo;
        private static TProperty k__BackingField;

       
        
        static  GenericBaseSome()
        {
            k__PropertyInfo = typeof(GenericBaseSome<TProperty>).GetProperty("GenericProperty", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        }
        
        public TProperty GenericProperty
        {
            get
            {
                return GetValue("GenericProperty", typeof(TProperty), k__PropertyInfo, k__BackingField, k__BackingField, ref k__BackingField);
            }
            set
            {
                SetValue("GenericProperty", typeof(TProperty), k__PropertyInfo, (object)value, value, ref k__BackingField);
            }
        }
        
        protected void SetValue<T>(string name, Type propertyType, PropertyInfo propertyInfo, object newValue, T genericNewValue,ref T refToBackingField)
        {

            refToBackingField = genericNewValue;
        }
        protected T GetValue<T>(string name, Type propertyType, PropertyInfo propertyInfo, object fieldValue, T genericFieldValue, ref T refToBackingField)
        {
            return genericFieldValue;
        }
    }
}