using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    public float ShowDialogueForSeconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            FindObjectOfType<DialogueManager>().CloseDialogueInSeconds(ShowDialogueForSeconds);
        }
    }

}
