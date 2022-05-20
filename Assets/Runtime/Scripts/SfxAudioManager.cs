using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxAudioManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    [SerializeField] AudioClip watering;
    [SerializeField] AudioClip pouringCan;
    [SerializeField] AudioClip crank;
    [SerializeField] AudioClip door;
    [SerializeField] AudioClip bucketOn;
    [SerializeField] private float sfxVolume;

    
    public void PlaySfx(AudioClip clip, float value)
    {
        if (sfxAudioSource != null)
        {

            sfxAudioSource.PlayOneShot(clip, value);
        }

    }

    public void WateringSound()
    {
       PlaySfx(watering, sfxVolume - 0.6f);
    }

    public void CrankSound()
    {
        PlaySfx(crank, sfxVolume - 0.8f);
    }

    public void PouringSound()
    {
        PlaySfx(pouringCan, sfxVolume);
    }

    public void DoorSound()
    {
        PlaySfx(door, sfxVolume);
    }

    public void BucketSound()
    {
        PlaySfx(bucketOn, sfxVolume-0.3f);
    }
}
