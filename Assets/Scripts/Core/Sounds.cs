using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string clipName;

    public AudioClip clip;

    public AudioSource source;

    public bool loop;

    [Range(0f, 1f)]
    public float volumn;

    [Range(.1f, 3f)]
    public float pitch;
}
