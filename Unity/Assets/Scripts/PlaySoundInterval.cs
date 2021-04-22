using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundInterval : MonoBehaviour
{
    public float intervalMin;
    public float intervalMax ;
    public float startTime;
    
    private float interval;
    private GameObject parent;
    private Component[] audioList;
    private AudioSource audioSource;
    
    
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject;
        audioList = parent.GetComponents(typeof(AudioSource));
        if(startTime != 0)
        {
          interval = startTime;
        }
        else
        {
          interval = Random.Range(intervalMin,intervalMax);
        }
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
            audioSource = audioList[Random.Range(0,(audioList.Length))] as AudioSource;
            audioSource.Play();
            interval = Random.Range(intervalMin,intervalMax);
        }
    }
}
