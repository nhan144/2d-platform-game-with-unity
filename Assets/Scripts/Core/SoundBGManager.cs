using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundBGManager : MonoBehaviour
{
    public AudioMixerGroup audioMixer;

    [SerializeField]
    private Sounds[] bgSounds;

    private void Awake()
    {
        foreach (Sounds bgs in bgSounds)
        {
            bgs.source = gameObject.AddComponent<AudioSource>();

            bgs.source.clip = bgs.clip;
            bgs.source.volume = bgs.volumn;
            bgs.source.loop = bgs.loop;
            bgs.source.pitch = bgs.pitch;
            bgs.source.outputAudioMixerGroup = audioMixer;
        }
    }

    private void Start()
    {

    }

    public void PlayBGSound(string bgSoundName)
    {
        Sounds bgs = Array.Find(bgSounds, bgsound => bgsound.clipName == bgSoundName);
        bgs.source.Play();
        bgs.source.loop = true;
    }

    public void StopBGSound(string bgSoundName)
    {
        Sounds bgs = Array.Find(bgSounds, bgsound => bgsound.clipName == bgSoundName);
        bgs.source.Stop();
    }

}
