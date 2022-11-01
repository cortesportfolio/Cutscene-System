using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NameArrayAttribute))]
public class NameArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        try
        {
            EditorGUI.ObjectField(rect, property, new GUIContent(((NameArrayAttribute) attribute).name));
        }
        catch
        {
            EditorGUI.ObjectField(rect, property, label);
        }
    }
}
