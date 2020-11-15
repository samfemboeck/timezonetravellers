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
    
    public void playbadmusic(float timeforplay=0f)
    {
        source.clip = badmusic;
        FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = false;
        Invoke("playclip", timeforplay);
    }

    public void playhappymusic(float timeforplay=0f)
    {
        source.clip = happymusic;
        Invoke("playclip", timeforplay);
    }

    public void playtransitionmusic(float timeforplay=0f)
    {
        source.clip = transition;
        source.volume = 1;
        FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = false;
        Invoke("playclip", timeforplay);
    }

    public void playtitlemusic(float timeforplay=0f)
    {
        source.clip = title;
        Invoke("playclip", timeforplay);
    }

    void playclip()
    {

        source.Play();
        FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enabled = true;
    }

}
