using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigScript : MonoBehaviour
{
    bool TutorialHasBeenTriggered = false;
   public DialogueTrigger RefToDialogueTrigger;
   private void OnTriggerEnter2D(Collider2D other) 
  {
      TutorialHasBeenTriggered = true;
        if (TutorialHasBeenTriggered)
      {
        RefToDialogueTrigger.TriggerDialogue();
      }
      else if (!TutorialHasBeenTriggered) 
      {
          TutorialHasBeenTriggered = false;
      } 
  }
}
