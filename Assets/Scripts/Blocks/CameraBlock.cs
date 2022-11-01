using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraBlock : CutsceneBlockBase
{
    [Space(25)]

    [Header("Camera")]
    public Camera cam;
    public Transform target;
    
    public override void StartBlock()
    {
        throw new System.NotImplementedException();
    }

    public override void RunBlock()
    {
        throw new System.NotImplementedException();
    }

    public override void EndBlock()
    {
        throw new System.NotImplementedException();
    }
}
