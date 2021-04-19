using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundInterval : MonoBehaviour
{
    public float interval = 5.0f;
    private float interval_return;

    public AudioSource audioSource;
    public AudioClip audioClip;
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        interval_return = interval;
    }

    // Update is called once per frame
    void Update()
    {
        if(interval > 0)
        {
            interval += -Time.deltaTime;

        }
        if(interval <= 0)
        {
            audioSource.PlayOneShot(audioClip);
            interval = interval_return;
        }
    }
}
