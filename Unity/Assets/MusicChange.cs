using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicChange : MonoBehaviour
{
    public AudioClip whispers;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       if(StaticValues.floor>9)
       {
         audioSource = GetComponent<AudioSource>();
         audioSource.clip = whispers;
         audioSource.Play();
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
