using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace CutsceneManager
{
    
    /// <summary>
    /// Add this component to add in a cutscene made from custom code blocks!
    /// </summary>\
    
    [DisallowMultipleComponent]
    public class Cutscene : MonoBehaviour
    {
        
        [Tooltip("Use me to check for bugs!")]
        [SerializeField]
        bool debug;
        
        [Tooltip("Use me to check for bugs!")]
        public List<CutsceneBlock> cutsceneEvents;
        
        [ShowIf("debug")]
        [Tooltip("This is the current block it's on")]
        int curIndex;

        
        /// <summary>
        /// Utilize this to begin the cutscene sequence!  	
        /// </summary>
        public void Begin()
        {
            Reset();
            TriggerNextBlock();
        }
        
        
        /// <summary>
        /// Please don't call this unless it's the block finishing!   	
        /// </summary>
        public void TriggerNextBlock()
        {
            if(curIndex >= cutsceneEvents.Count)
                End();
            
            cutsceneEvents[curIndex].block.ResetBlock();
            cutsceneEvents[curIndex].block.StartBlock();
            
            curIndex++;
        }

        

        public IEnumerator WaitForBlock()
        {
            yield return new WaitForEndOfFrame();
            
            while (cutsceneEvents[curIndex].block.hasFinished)
            {
                yield return new WaitForEndOfFrame();
            }

            TriggerNextBlock();
        }
        
        // This lets the system update each code block automatically based on it's type. Each block utilizes the base
        // class and allows the user to create their own blocks! The system reasons the base block with the polymorphed
        // classes to run their own custom needs!
        private void OnValidate()
        {
            //Debug.Log("Validating Cutscene");
            foreach (CutsceneBlock cutsceneBlock in cutsceneEvents)
            {
                cutsceneBlock.UpdateCutsceneBlocks();
            }
        }

        /// <summary>
        /// Please do not utilize this! This will get automatically called when all parts of the cutscene are finished!	
        /// </summary>
        public void End()
        {
            
        }

        /// <summary>
        /// Use this to reset the cutscene! It should be automatically called when beginning the cutscene, to ensure it
        /// starts appropriately!
        /// </summary>
        public void Reset()
        {
            curIndex = 0;
        }
    }
    
    
    
}