using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Field,AllowMultiple = true)]
public class NoLabelAttribute : PropertyAttribute
{
    public void NoLabel()
    {
        
    }
}
