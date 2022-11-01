using System;
using UnityEngine;



[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class ShowIfAttribute : PropertyAttribute
{
    public string conditionFieldName;
    public string scopeName = "";
    public bool hideArray;
    
    /// <summary>
    /// Use this Attribute to hide properties based on another property!
    /// </summary>
    /// <param name="conditionFieldName">Use ' "Param Name" ' for the field name.</param>
    public ShowIfAttribute(string conditionFieldName)
    {
        this.conditionFieldName = conditionFieldName;
    }

    /// <summary>
    /// Use this Attribute to hide properties based on another property!
    /// In some weird instances, due to inheritance, use this!
    /// </summary>
    /// <param name="conditionFieldName">Use ' "Param Name" ' for the field name.</param>
    /// <param name="scopeName">Use ' "Scope Name" ' to define the scope!</param>
    public ShowIfAttribute(string conditionFieldName, string scopeName)
    {
        this.conditionFieldName = conditionFieldName;
        this.scopeName = scopeName;
    }
    
    // public ShowIfAttribute(string conditionFieldName, string scopeName, bool hideArray)
    // {
    //     this.conditionFieldName = conditionFieldName;
    //     this.scopeName = scopeName;
    //     this.hideArray = hideArray;
    // }
}
