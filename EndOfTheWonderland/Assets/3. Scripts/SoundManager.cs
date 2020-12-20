using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    static SoundManager instance = null;

    public AudioClip[] audioClips;
    public enum SoundName { Big, ButtonClick, Collision, Jump, Small}

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private AudioSource audioSource;
    public static SoundManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
            }
            return instance;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundName name)
    {
        audioSource.clip = (audioClips[(int)name]);
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }
}