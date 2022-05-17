using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialTrigScript : MonoBehaviour
{

    bool TutorialHasBeenTriggered = false;
    public GameObject RefToDialogueBox;
   public DialogueTrigger RefToDialogueTrigger;
   private void OnTriggerEnter2D(Collider2D other) 
  {
      TutorialHasBeenTriggered = true;
        if (TutorialHasBeenTriggered)
      {
           //clear selected button 
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected button
        EventSystem.current.SetSelectedGameObject(RefToDialogueBox);
        RefToDialogueTrigger.TriggerDialogue();
      }
      
  }
}
