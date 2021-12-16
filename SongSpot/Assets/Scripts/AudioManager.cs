using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private int currentTrack;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        //play music
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic()
    {
        if (source.isPlaying)
        {
            return;
        }
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        StartCoroutine(waitForMusictoEnd());
    }

    IEnumerator waitForMusictoEnd()
    {
        while (source.isPlaying)
        {
            yield return null;

        }
        NextTitle();
    }

    public void NextTitle()
    {
        source.Stop();
        currentTrack++;
        if(currentTrack > musicClips.Length - 1)
        {
            currentTrack = 0;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        //show title
        StartCoroutine(waitForMusictoEnd());
    }

    public void PreviousTitle()
    {
        source.Stop();
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        //show title
        StartCoroutine(waitForMusictoEnd());
    }
    public void StopMusic()
    {
        //StopAllCoroutines;
        StopCoroutine("waitForMusictoEnd");
        source.Stop();
    }
    public void MuteMusic()
    { 
        source.mute = !source.mute;
    }
}
