using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using log4net.Util;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace CutsceneManager
{
    //[CustomEditor(typeof(CutsceneBlock))]
    public class CutsceneBlockEditor : Editor
    {
        /*public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            
            EditorGUI.indentLevel = 0;

            float widthSize = position.width / 2;
            
            Rect nameRect = new Rect(position.x, position.y, widthSize, position.height);
            Rect typeRect = new Rect(position.x + widthSize * 1, position.y, widthSize, position.height);
            
            EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("BlockName"), GUIContent.none);
            EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("blockType"), GUIContent.none);

            EditorGUI.indentLevel = indent;
            
            EditorGUI.EndProperty();
            
            //EditorGUI.BeginChangeCheck();

            //EditorGUI.Foldout(position, property.isExpanded,label);
            //Rect blockRect = new Rect(position.x, EditorGUIUtility.singleLineHeight * 2, position.width, position.height);

            //EditorGUI.PropertyField(blockRect, property.FindPropertyRelative("block"), GUIContent.none);
            
            //EditorGUI.EndProperty();
        }*/
    }
}