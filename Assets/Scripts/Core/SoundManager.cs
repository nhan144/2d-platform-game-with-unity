using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public AudioMixerGroup audioMixer;

    [SerializeField]
    private Sounds[] sounds;


    private void Awake()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volumn;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = audioMixer;
        }
    }

    public void PlaySound(string soundName)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.clipName == soundName);
        s.source.Play();
    }

}
