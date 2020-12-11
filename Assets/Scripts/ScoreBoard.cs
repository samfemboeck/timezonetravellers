using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public GameObject SplashScreen;
    public GameEvent CorruptEvent;
    public Text ScoreText;
    public Fade Fade;
    public Image PoppyImage;
    public Sprite PoppyBadSprite;
    public PlayerMovement PlayerMovement;
    float _initialBalloonCount;
    float _balloonsPopped = 0;

    void Start()
    {
        ScoreText.text = "Pop Count: " + _balloonsPopped;
    }

    void IncrementScore()
    {
        ScoreText.text = "Pop Count: " + ++_balloonsPopped;
        if (_balloonsPopped == 10)
        {
            StartCoroutine(ToggleCorrupt(0));
            StartCoroutine(ToggleCorrupt(1));
            AudioManager.Instance.StopMusic();
            StartCoroutine(AudioManager.Instance.PlayClip("bad-music", true, 1, Source.Music, 2f));
        }
        if (_balloonsPopped == 15)
        {
            StartCoroutine(FlickerCorrupt());
            AudioManager.Instance.StopMusic();
            StartCoroutine(AudioManager.Instance.PlayClip("transition", true, 1, Source.Music, 2f));
            Invoke("MakePoppyCorrupt", 2);
            Invoke("TriggerDialogue", 7);
            Invoke("FadeToBlack", 10);
            Invoke("ShowSplashScreen", 18);
            Invoke("MakeFireplaceCorrupt", 2);
            PoppyImage.sprite = PoppyBadSprite;
        }
    }

    void MakeFireplaceCorrupt()
    {
        FindObjectOfType<FireplaceCorrupt>().GoCorrupt();
    }

    void MakePoppyCorrupt()
    {
        PlayerMovement.GoCorrupt();
    }

    void FadeToBlack()
    {
        StartCoroutine(Fade.FadeBlackOutSquare(true));
    }

    void TriggerDialogue()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    IEnumerator FlickerCorrupt()
    {
        for (int i = 0; i < 11; ++i)
        {
            yield return StartCoroutine(ToggleCorrupt(0.2f));
        }
    }

    IEnumerator ToggleCorrupt(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (GoCorrupt corrupt in FindObjectsOfType<GoCorrupt>())
            corrupt.Toggle();
        yield return null;
    }

    public void ShowSplashScreen()
    {
        SplashScreen.SetActive(true);
    }

    void tempdisableplayer()
    {
        //FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = true;
        //FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = true;
    }

}
