using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public enum Source { Music, Wind }

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource windSource;

    [SerializeField] AudioClip happyMusic;
    [SerializeField] AudioClip badMusic;
    [SerializeField] AudioClip transitionMusic;
    [SerializeField] AudioClip titleMusic;
    [SerializeField] AudioClip popBalloon;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip wind;
    [SerializeField] AudioClip bounce_off_balloon_1;
    [SerializeField] AudioClip bounce_off_balloon_2;
    [SerializeField] AudioClip creepy_sound;
    [SerializeField] AudioClip slingshot;

    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    void Awake()
    {
        Instance = this;
        _audioClips.Add("happy-music", happyMusic);
        _audioClips.Add("bad-music", badMusic);
        _audioClips.Add("transition", transitionMusic);
        _audioClips.Add("title-music", titleMusic);
        _audioClips.Add("pop-balloon", popBalloon);
        _audioClips.Add("walk", walk);
        _audioClips.Add("wind", wind);
        _audioClips.Add("bounce_off_balloon_1", bounce_off_balloon_1);
        _audioClips.Add("bounce_off_balloon_2", bounce_off_balloon_2);
        _audioClips.Add("creepy_sound", creepy_sound);
        _audioClips.Add("slingshot", slingshot);
    }

    public IEnumerator PlayClip(string clip, bool loop, float volume, Source source, float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayClip(clip, loop, volume, source);
        yield return null;
    }

    public void PlayClip(string clip, bool loop, float volume, Source source)
    {
        AudioSource targetSource = null;
        if (source == Source.Music)
            targetSource = musicSource;
        else if (source == Source.Wind)
            targetSource = windSource;

        targetSource.volume = volume;
        targetSource.clip = _audioClips[clip];
        targetSource.loop = loop;
        targetSource.Play();
    }

    // You can use playoneshot to play multiple sounds simultaneously
    public void PlayOneShot(string clip, float volume)
    {
        musicSource.PlayOneShot(_audioClips[clip], volume);
    }
}
