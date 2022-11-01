using System;
using System.Collections;
using System.Collections.Generic;
using CutsceneManager;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This is the base block class to cutscene blocks!
/// Use this to create your very own block of code! And don't forget to add in the needed blocks!	
/// </summary>
[System.Serializable]
public abstract class CutsceneBlockBase
{
    [Multiline]
    //[NoLabel]
    [Tooltip("This is just a designer only description of what the block is doing.")]
    public string Description;

    [Header("Base")]
    [Tooltip("Should it wait until the end to start the new block?")]
    [SerializeField] protected internal bool waitForEnd = true;

    [ShowIf("waitForEnd")]
    [Tooltip("If it cannot reach the end, how long should it wait for between actions?")]
    [SerializeField] protected internal float timer = 2;
    
    [ReadOnly]
    [Tooltip("Great at showing when a block has finished for debug/visual purposes!")]
    public bool hasFinished;

    [HideInInspector]
    public Cutscene cutscene;

    /// <summary>
    /// What should the block do every time it is reset? This works great when you need a Cutscene to replay, ensuring
    /// values are reset appropraitely.
    /// </summary>
    public virtual void ResetBlock()
    {
        hasFinished = false;
    }

    /// <summary>
    /// The start block! This is required and plays on the start.
    /// </summary>
    public abstract void StartBlock();
    
    /// <summary>
    /// The Run block! This is required and runs like an update. While it's useful in some cases, most chances are you
    /// will most likely not touch this!
    /// </summary>
    public abstract void RunBlock();

    /// <summary>
    /// The End block! This is required and plays at the end. This is useful for wrapping things up with the block and
    /// moving onward to the next one!
    /// </summary>
    public abstract void EndBlock();
}