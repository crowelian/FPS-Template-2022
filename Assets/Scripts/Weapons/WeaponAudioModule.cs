using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudioModule : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioShoot;
    [SerializeField]
    private AudioClip audioReload;
    [SerializeField]
    private AudioClip audioEmptyMagazine;
    [SerializeField]
    private AudioSource weaponAudioSource;

    private void Start()
    {
        if (weaponAudioSource == null) gameObject.AddComponent<AudioSource>();
    }

    public void PlayShootAudio()
    {
        if (audioShoot != null)
        {
            weaponAudioSource.clip = audioShoot;
            if (!weaponAudioSource.isPlaying)
            {
                
                weaponAudioSource.Play();
            }
            
        } else
        {
            Debug.Log("You must add audioShoot audio!");
        }
        
    }

    public void PlayReloadAudio()
    {
        if (audioShoot != null)
        {
            weaponAudioSource.clip = audioReload;
            if (!weaponAudioSource.isPlaying)
            {
                
                weaponAudioSource.Play();
            }
           
        }
        else
        {
            Debug.Log("You must add audioReload audio!");
        }

    }

    public void PlayEmptyMagazineAudio()
    {
        if (audioShoot != null)
        {
            weaponAudioSource.clip = audioEmptyMagazine;
            if (!weaponAudioSource.isPlaying)
            {
                
                weaponAudioSource.Play();
            }
            
        }
        else
        {
            Debug.Log("You must add audioEmptyMagazine audio!");
        }

    }

}
