using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public GameEvent CorruptEvent;
    public Text ScoreText;
    float _initialBalloonCount;
    float _balloonsPopped = 0;

    void Start()
    {
        _initialBalloonCount = 15;
        ScoreText.text = "Pop Count: " + _balloonsPopped;
    }

    void IncrementScore()
    {
        ScoreText.text = "Pop Count: " + ++_balloonsPopped;
        if(_balloonsPopped==9)
        {
            AudioManager.Instance.PlayClip("badMusic",true,1,Source.Music,2f);
            FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = false;
            Invoke("tempdisableplayer",2f);

        }
        if(_balloonsPopped == _initialBalloonCount)
        {
            foreach (GoCorrupt corrupt in FindObjectsOfType<GoCorrupt>())
                corrupt.GoCurrupt();

            GetComponent<DialogueTrigger>().TriggerDialogue();
            FindObjectOfType<DialogueManager>().CloseDialogueInSeconds(2);

            AudioManager.Instance.PlayClip("transitionMusic", true, 1, Source.Music, 2f);
            FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<PlayerMovement>().GetComponent<Slingshot>().enabled = false;
        }
    }

    void tempdisableplayer()
    {
        FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = true;
        FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = true;
    }
    
}
