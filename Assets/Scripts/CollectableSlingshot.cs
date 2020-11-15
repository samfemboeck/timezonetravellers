using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSlingshot : MonoBehaviour
{
    public GameObject InvisibleWall;
    public float ShowDialogueForSeconds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvisibleWall.SetActive(false);
            GetComponent<DialogueTrigger>().TriggerDialogue();
            FindObjectOfType<DialogueManager>().CloseDialogueInSeconds(ShowDialogueForSeconds);
            Destroy(gameObject);
        }
    }
}
