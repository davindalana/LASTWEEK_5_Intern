using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dialogue != null)
        {
            dialogue.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (dialogue != null)
        {
            dialogue.gameObject.SetActive(false);
        }
    }
}

