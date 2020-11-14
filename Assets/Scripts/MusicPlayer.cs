using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip happymusic;
    [SerializeField] AudioClip badmusic;
    [SerializeField] AudioClip transition;
    [SerializeField] AudioClip title;
    [SerializeField] bool changemusic=false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void playbadmusic()
    {
        source.clip = badmusic;
        source.Play();
    }

    public void playhappymusic()
    {
        source.clip = happymusic;
        source.Play();
    }

    public void playtransitionmusic()
    {
        source.clip = transition;
        source.Play();
    }

    public void playtitlemusic()
    {
        source.clip = title;
        source.Play();
    }
}
