using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManagerScript : MonoBehaviour
{
    public Animator RefToAnimator;
    public TextMeshProUGUI nameText, dialogueText;
    public GameObject RefToDialogueBox, RefToSkipButton;

    Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        RefToAnimator.SetBool("DialogueBoxIsOpen", true);
        Debug.Log("Starting conversation with " + dialogue.name);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected button
        EventSystem.current.SetSelectedGameObject(RefToSkipButton);
        DisplayNextSentence();
    }
    public void PressTriangleToSubmit()
    {
        if (RefToDialogueBox.activeInHierarchy)
        {
        //clear selected button 
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected button
        EventSystem.current.SetSelectedGameObject(RefToSkipButton);
            if (Input.GetButtonDown("Submit"))
            {
                DisplayNextSentence();
            }
        }

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    void EndDialogue()
    {
        Debug.Log("End of conversation");
        RefToAnimator.SetBool("DialogueBoxIsOpen", false);
    }


}
