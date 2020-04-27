using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        // Create audio sources of all sounds
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private String currName = "";

    public void PlaySound(string name)
    {
        currName = name;

        float num = UnityEngine.Random.Range(0.5f, 2f);

        Invoke("playAudio", num);
    }


    public void playAudio()
    {
        Sound s = Array.Find(sounds, sound => sound.name == currName);

        if (s == null)
        {
            Debug.Log("COULD NOT FIND SOUND: " + currName);
            return;
        }

        if (!s.source.isPlaying)
        {
            s.source.Play();
        }

        
    }
}
