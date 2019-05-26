using System;
using System.Collections.Generic;
using System.Reflection;
using AutoProperties;


public class ParentWithGenericBaseOfInt : GenericBaseSome<int>
{
}


public abstract class GenericBaseSome<TProperty> : ChangeTrackable
{
    public TProperty GenericProperty { get; set; }
}


public abstract class ChangeTrackable
{
    public virtual Action<object, string> NotifyPropertyChanged { get; set; }

    public virtual HashSet<string> ChangedProperties { get; } = new HashSet<string>();
    
    [SetInterceptor]
    protected void SetValue<T>(string name, Type propertyType, PropertyInfo propertyInfo, object newValue, T genericNewValue,
        ref T refToBackingField)
    {

        refToBackingField = genericNewValue;
        ChangedProperties?.Add(name);
    }
    [GetInterceptor]
    protected T GetValue<T>(string name, Type propertyType, PropertyInfo propertyInfo, object fieldValue, T genericFieldValue, ref T refToBackingField)
    {
        return genericFieldValue;
    }
}