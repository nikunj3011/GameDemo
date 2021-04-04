using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource source;
    public AudioClip win,loss;


    void Awake()
    {
        Instance = this;
    }
    public void PlaySounds()
    {
        if (source.clip != null)
        {
            source.Play();
        }
    }

    public void StopSounds()
    {
        if (source.clip != null)
        {
            source.Stop();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
