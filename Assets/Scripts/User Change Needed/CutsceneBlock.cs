using System;
using System.Collections;
using System.Collections.Generic;
using CutsceneManager;
using UnityEngine;

[System.Serializable]
public class CutsceneBlock
{
    [SerializeField] internal string BlockName;
    [SerializeField] public BlockType blockType;
   
    //---------------------------------------------------------------------
    //USER INPUT NEEDED//
    //Please add in custom block types to this enum to make it selectable!
    public enum BlockType
    {
        Actor,
        Camera,
        Dialogue
    }

    //-----------------------------------------------------------------------
    
    //[NoLabel]
    [SerializeReference] public CutsceneBlockBase block = new ActorBlock();
    
    //---------------------------------------------------------------------
    //USER INPUT NEEDED//
    //Please add in switch statements based on enum choices to make it selectable!
    public void UpdateCutsceneBlocks()
    {
        //Debug.Log("Validating Block!");
        switch (blockType)
        {
            case BlockType.Actor:
                if(!(block is ActorBlock))
                {
                    block = new ActorBlock();
                    BlockName = "Actor Block";
                }
                break;
            case BlockType.Camera:
                if(!(block is CameraBlock))
                {
                    block = new CameraBlock();
                    BlockName = "Camera Block";
                }
                break;
            case BlockType.Dialogue:
                if(!(block is DialogueBlock))
                {
                    block = new DialogueBlock();
                    BlockName = "Dialogue Block";
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    //---------------------------------------------------------------------
    
}


