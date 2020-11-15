using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float BalloonPopVolume;
    public float BalloonBounceVolume;
    public float HappyMusicVolume;
    public float WindVolume;
    public float SlingshotVolume;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayClip("happy-music", true, HappyMusicVolume, AudioManager.Source.Music);
        AudioManager.Instance.PlayClip("wind", true, WindVolume, AudioManager.Source.Wind);
    }

    // Update is called once per frame
    void Update()
    {
        
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
