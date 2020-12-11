using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameEvent GoCorrupt;
    public DialogueManager DialogueManager;
    public float BalloonPopVolume;
    public float BalloonBounceVolume;
    public float HappyMusicVolume;
    public float WindVolume;
    public float SlingshotVolume;
    public Fade Fade;
    bool _gameStarted = false;
    bool _inputActive = true;

    // Start is called before the first frame update
    void Start()
    {
        //StartGame();
    }

    void StartGame()
    {
        _gameStarted = true;
        _inputActive = true;
        DialogueManager.DisplayNextSentence();
        AudioManager.Instance.PlayClip("happy-music", true, HappyMusicVolume, Source.Music);
        AudioManager.Instance.PlayClip("wind", true, WindVolume, Source.Wind);
    }

    IEnumerator Init()
    {
        _inputActive = false;
        yield return StartCoroutine(Fade.FadeBlackOutSquare(false));
        StartGame();
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
        {
            if (!_inputActive)
                return;

            if (!_gameStarted)
                StartCoroutine(Init());
            else
                DialogueManager.DisplayNextSentence();
        }
    }

    public void PlayBalloonPop() => AudioManager.Instance.PlayOneShot("pop-balloon", BalloonPopVolume);

    public void PlayBalloonBounce()
    {
        if (Random.value > 0.5f)
            AudioManager.Instance.PlayOneShot("bounce_off_balloon_1", BalloonBounceVolume);
        else
            AudioManager.Instance.PlayOneShot("bounce_off_balloon_2", BalloonBounceVolume);
    }

    public void PlaySlingshot() => AudioManager.Instance.PlayOneShot("slingshot", SlingshotVolume);
}
