using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip happymusic;
    [SerializeField] AudioClip badmusic;
    [SerializeField] AudioClip transition;
    // Start is called before the first frame update
    void Start()
    {
        source.clip = happymusic;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
