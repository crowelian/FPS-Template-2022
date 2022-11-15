using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void PlayAudioIfNotPlaying(AudioSource playThis, bool noWait = false)
    {
        if (playThis == null)
        {
            return;
        }
        if (playThis.isPlaying && noWait == false)
        {
            return;
        }

        playThis.Play();
    }
}
