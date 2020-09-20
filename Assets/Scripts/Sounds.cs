using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound { 
    public AudioClip clip;
    public float volume;
    public float pitch;
    [HideInInspector]
    public AudioSource source;

    public string name;
}
