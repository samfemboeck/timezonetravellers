using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueText;

    public Animator Animator;

    private Queue<string> _sentences = new Queue<string>();

    private void Start()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue)
    {
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
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        DialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Animator.SetBool("IsOpen", false);
    }
}
