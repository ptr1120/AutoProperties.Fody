using System;
using System.Collections.Generic;
using System.Reflection;
using AutoProperties;

namespace Tests
{
    public class IntSome: GenericBaseSome<int>
    {
        
    }
    public class StringSome: GenericBaseSome<int>
    {
        
    }
    public class GenericBaseSome<TProperty>:ChangeTrackable
    {
        private static PropertyInfo k__PropertyInfo;
        private  TProperty k__BackingField;

       
        
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
        
    }
}
public class SomeClassWithoutGenerics : ChangeTrackable
{
    private static PropertyInfo v__PropertyInfo;
    private  int v__BackingField;
    
    private static PropertyInfo r__PropertyInfo;
    private  string r__BackingField;
    
    private static PropertyInfo a__PropertyInfo;
    private  string[] a__BackingField;

    public int ValueProperty
    {
        get
        {
            return base.GetValue<int>("ValueProperty", typeof(int), v__PropertyInfo, v__BackingField, v__BackingField, ref v__BackingField);
        }
        set
        {
            base.SetValue<int>("ValueProperty", typeof(int), v__PropertyInfo, value, value, ref v__BackingField);
        }
    }

    public string ReferenceProperty
    {
        get
        {
            return base.GetValue<string>("ReferenceProperty", typeof(string), r__PropertyInfo, r__BackingField, r__BackingField, ref r__BackingField);
        }
        set
        {
            base.SetValue<string>("ReferenceProperty", typeof(string), r__PropertyInfo, (object)value, value, ref r__BackingField);
        }
    }

    public string[] ArrayProperty
    {
        get
        {
            return base.GetValue<string[]>("ArrayProperty", typeof(string[]), a__PropertyInfo, a__BackingField, a__BackingField, ref a__BackingField);
        }
        set
        {
            base.SetValue<string[]>("ArrayProperty", typeof(string[]), a__PropertyInfo, (object)value, value, ref a__BackingField);
        }
    }
}


public abstract class ChangeTrackable
{
    public virtual HashSet<string> ChangedProperties { get; } = new HashSet<string>();

    protected void SetValue<T>(string name, Type propertyType, PropertyInfo propertyInfo, object newValue, T genericNewValue,
        ref T refToBackingField)
    {
        refToBackingField = genericNewValue;
        ChangedProperties?.Add(name);
    }

    protected T GetValue<T>(string name, Type propertyType, PropertyInfo propertyInfo, object fieldValue, T genericFieldValue, ref T refToBackingField)
    {
        return genericFieldValue;
    }
}