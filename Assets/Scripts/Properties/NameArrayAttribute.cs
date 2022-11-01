using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameArrayAttribute : PropertyAttribute
{
    public readonly string name;

    public NameArrayAttribute(string name)
    {
        this.name = name;
    }
}
