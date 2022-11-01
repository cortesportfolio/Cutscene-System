using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CutsceneManager
{


    [CustomEditor(typeof(Cutscene))]
    public class CutsceneEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Cutscene cutscene = (Cutscene) target;
            if (GUILayout.Button("Test Me"))
            {
                cutscene.TriggerNextBlock();
            }
        }
    }
}