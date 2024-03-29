﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public DialogueManagerScript ReftoDialogueManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (ReftoDialogueManager.HasSentenceEnded == true)
        {
            StartCoroutine(NextSceneLoader());
            ReftoDialogueManager.HasSentenceEnded = false;
        }


    }

    public IEnumerator NextSceneLoader()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
