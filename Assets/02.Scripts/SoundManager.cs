using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject prefabs;

    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        
    }
    public void GetCoin(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    

    }
}
