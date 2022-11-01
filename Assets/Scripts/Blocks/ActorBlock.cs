using System.Collections;
using System.Collections.Generic;
using CutsceneManager;
using GlobalIenums;
using UnityEngine;
using UnityEngine.UIElements;

//Important things to note:
//Transform[] actors will need to be given the correct actors in the scene. This can be done by feeding it values

[System.Serializable]
public class ActorBlock : CutsceneBlockBase
{
    [Space(25)]
    [Header("Actor Block")]
    [Tooltip("The actors that will be used for actions")]
    public ActorManager.ActorDatabase[] actors = new ActorManager.ActorDatabase[1];
    protected List<Animator> anims = new List<Animator>();
    
    public bool setDestination;
    
    [ShowIf("setDestination")]
    [Tooltip("Should wait for movement to end before continuing on?")]
    public bool waitForMovement;
    [Tooltip("Destinations! If this length matches the actors, it will make each actor follow to the appropriate destination.")]
    [SerializeField] public Transform[] destinationObj = new Transform[1];


    [Header("Animation")]
    [Tooltip("Should it animate?")]
    public bool animate;
    [ShowIf("animate")]
    [Tooltip("What animation?")]
    public AnimationEnum animationCall;

    [Tooltip("Should it wait for an animation to finish playing?")]
    public bool waitForAnimation;
    [ShowIf("waitForAnimation")]
    [Tooltip("What layer should it watch for in the animator?")]
    public int stateLayer;

    
    public override void StartBlock()
    {
        //Grabs all anims from the Actor Manager instance. This allows for ease of use so the actors asked for do not need
        //to be preset or in the scene for this system to work!
        
        if(animate)
            for (int index = 0; index < actors.Length; index++)
            {
                anims.Add(ActorManager.Instance.GetActor(actors[index]).GetComponent<Animator>());
                anims[index].Play(animationCall.ToString());
            }

        if (setDestination)
        {
            //Run the set destination code here
            //**SETUP**--------------------------------------------
            for (int index = 0; index < actors.Length; index++)
            {
                ActorManager.Instance.GetActor(actors[index]).position = destinationObj[index].position;
            }
        }

        if (waitForAnimation)
        {
            cutscene.StartCoroutine(WaitForAnimation());
        }
    }

    public override void RunBlock()
    {
        //Left Null Intentionally
    }

    public override void EndBlock()
    {
        cutscene.TriggerNextBlock();
    }

    public IEnumerator WaitForAnimation()
    {
        //Frame Buffer, secures that no nulls are present in logic
        yield return new WaitForEndOfFrame();

        foreach (Animator anim in anims)
        {
            if (anim.GetCurrentAnimatorStateInfo(stateLayer).IsName(animationCall.ToString()))
                yield return null;
        }
        
        CheckForDestinationCheck();
    }

    public void CheckForDestinationCheck()
    {
        if (waitForMovement)
            cutscene.StartCoroutine(WaitForDestination());
        else
        {
            EndBlock();
        }
    }
    
    //While placed inside of this block, it's important to note that it must be run outside of the block!
    //IEnumerators can only run off of monobehaviours, and since this is based off of an abstract class that does not
    //inherent from monobehaviour...
    //It utilizes the Cutscene Monobehaviour script to run this Coroutine!
    public IEnumerator WaitForDestination()
    {
        //Frame Buffer, secures that no nulls are present in logic
        yield return new WaitForEndOfFrame();

        //Instead of checking positioning, it instead checks for the speed of the animator. Due to the way the characters
        //move, this allows us to check if they have been in transit, or if they are finished moving.
        foreach (Animator anim in anims)
        {
            while (anim.GetFloat("Speed") > 0)
            {
                yield return null;
            }
        }
        
        EndBlock();
    }
}