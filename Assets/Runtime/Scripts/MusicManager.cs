using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip dayOneClip;
    [SerializeField] AudioClip dayTwoClip;
    [SerializeField] AudioClip dayThreeClip;
    [SerializeField] AudioClip finalDayClip;
    [SerializeField] AudioClip colorModeClip;
    [SerializeField] float musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        OneDayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void OneDayMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(musicVolume, 10);
            PlayClip(dayOneClip);
        }

    }
    public void TwoDayMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(musicVolume, 5);
            PlayClip(dayTwoClip);
        }

    }
    public void ThreeDayMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(musicVolume, 5);
            PlayClip(dayThreeClip);
        }

    }
    public void FinalDayMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(musicVolume, 5);
            PlayClip(finalDayClip);
        }

    }

    public void ColorModeMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(musicVolume, 5);
            PlayClip(colorModeClip);
        }
    }

    public void FadeOutMusic()
    {
        if(audioSource != null)
        {
            audioSource.DOFade(0, 5);
        }
    }


}
