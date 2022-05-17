using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerScript : MonoBehaviour
{
    Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }


}
