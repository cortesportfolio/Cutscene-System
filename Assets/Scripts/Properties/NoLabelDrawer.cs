using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(NoLabelAttribute))]
public class NoLabelDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // SerializedObject obj = new UnityEditor.SerializedObject(property.objectReferenceValue);
        // SerializedProperty ite = obj.GetIterator();
        //
        // float totalHeight = EditorGUI.GetPropertyHeight(property, label);
        //

        //Rect newRect = new Rect(position.x, position.y, position.width, position.height);

        

        NoLabelAttribute noLabel = attribute as NoLabelAttribute;
        //EditorGUI.Foldout(position, true, GUIContent.none);
        EditorGUI.PropertyField(position, property, GUIContent.none);
        //position.height = totalHeight;
    }
}
