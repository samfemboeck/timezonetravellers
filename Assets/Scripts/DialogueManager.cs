using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueText;

    public Animator Animator;
    private Queue<string> _sentences = new Queue<string>();
    bool _dialogueActive = false;

    private void Start()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<PlayerMovement>().CanWalk = false;
        _dialogueActive = true;
        Animator.SetBool("IsOpen", true);

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!_dialogueActive)
            return;

        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        DialogueText.text = sentence;
    }

    public void CloseDialogueInSeconds(float seconds)
    {
        Invoke("EndDialogue", seconds);
    }

    public void EndDialogue()
    {
        FindObjectOfType<PlayerMovement>().CanWalk = true;
        _dialogueActive = false;
        Animator.SetBool("IsOpen", false);
    }
}
