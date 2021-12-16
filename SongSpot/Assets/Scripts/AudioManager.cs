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
    
    public Text clipTitleText;
    public Text clipTimeText;

    private int fullLength;
    private int playTime;
    private int seconds;
    private int minutes;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        //play music
        //PlayMusic();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForMusicToEnd()
    {
        while (source.isPlaying)
        {
            playTime = (int)source.time;
            ShowPlayTime();
            yield return null;

        }

        NextTitle();
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
        StartCoroutine(WaitForMusicToEnd());
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
        StartCoroutine(WaitForMusicToEnd());
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
        StartCoroutine(WaitForMusicToEnd());
    }
    public void StopMusic()
    {
        //StopAllCoroutines;
        StopCoroutine(WaitForMusicToEnd());
        source.Stop();
    }
    public void MuteMusic()
    { 
        source.mute = !source.mute;
    }
    public void ShowPlayTime()
    {
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;
        clipTimeText.text = minutes + ":" + seconds.ToString("D2") + "/" + ((fullLength / 60) % 60);
    }
}
