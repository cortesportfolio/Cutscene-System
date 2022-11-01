using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfPropertyDrawer : PropertyDrawer
{
    private bool showField = true;
    private SerializedProperty arrayToHide;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIfAttribute = (ShowIfAttribute) this.attribute;
        SerializedObject obj = property.serializedObject;
        SerializedProperty conditionalField = GetCorrectPath(obj, property);
        SerializedProperty iterator = property.Copy();

        if (conditionalField == null)
        {
            ShowError(position, label, "Error, the conditional field does not exist! Check the name.");
            return;
        }

        switch (conditionalField.propertyType)
        {
            case SerializedPropertyType.Boolean:
                //Debug.Log("Checking Boolean");
                showField = conditionalField.boolValue;
                break;
            default:
                ShowError(position, label, "Error, type has no support yet! At the moment only bools!");
                break;
        }
        
        if (showField)
            EditorGUI.PropertyField(position, property, label, false);
    }

    //For this property drawer, due to inheritance, I needed to run through pathing to find the appropriate properties!
    //Usually this is not a problem for components, but for the Cutscene component it has multiple child components to it.
    //This recursively checks for where the var is in terms of inheritance and then swaps out the correct var
    //to check for.
    private SerializedProperty GetCorrectPath(SerializedObject obj, SerializedProperty property)
    {
        string findCorrectPropertyPath = property.propertyPath;
        ShowIfAttribute showIfAttribute = (ShowIfAttribute) this.attribute;
        
        // if (showIfAttribute.conditionFieldName == "setDestination")
        // {
        //     Debug.Log(property.displayName);
        //     Debug.Log(property.propertyPath);
        // }
        
        if(showIfAttribute.scopeName == "")
            findCorrectPropertyPath = property.propertyPath.Split(property.name)[0];
        else
        {
            findCorrectPropertyPath = property.propertyPath.Split(showIfAttribute.scopeName)[0];
            //Debug.Log(findCorrectPropertyPath);
        }
        
        // if (findCorrectPropertyPath.EndsWith("Array"))
        //     findCorrectPropertyPath.Remove(findCorrectPropertyPath.LastIndexOf("Array") + 1);

        //if (showIfAttribute.hideArray)
          //  arrayToHide = obj.FindProperty(findCorrectPropertyPath);
        
        findCorrectPropertyPath += showIfAttribute.conditionFieldName;

        return obj.FindProperty(findCorrectPropertyPath);
    }
    
    private void ShowError(Rect position, GUIContent label, string errorText)
    {
        EditorGUI.LabelField(position, label, new GUIContent(errorText));
        showField = true;
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (showField)
            return EditorGUI.GetPropertyHeight(property);
        else
            return -EditorGUIUtility.standardVerticalSpacing;
    }
}
