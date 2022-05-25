using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollisionSceneChange : MonoBehaviour
{
    public DialogueManagerScript ReftoDialogueManager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ReftoDialogueManager.HasSentenceEnded == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                ReftoDialogueManager.HasSentenceEnded = false;
            }

        }
    }
}
