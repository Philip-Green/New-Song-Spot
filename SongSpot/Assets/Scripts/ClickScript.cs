using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public AudioSource[] a1Sounds;
    public AudioSource song1;
    public AudioSource song2;
    public AudioSource song3;
   
    //AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        //ac = GetComponent<AudioSource>();
        a1Sounds = GetComponents<AudioSource>();
        song1 = a1Sounds[0];
        song2 = a1Sounds[1];
        song3 = a1Sounds[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // Destroy(gameObject);
        //ac.PlayOneShot(ac.clip);
        a1Sounds[Random.Range(0, a1Sounds.Length)].Play();
        
    }
}