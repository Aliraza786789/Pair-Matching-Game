using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        foreach (var sound in sounds)
        {
            GameObject game = new GameObject();
            game.transform.SetParent(this.transform);
            game.name = sound.soundEnum.ToString();
            sound.source = game.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(SoundName soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundEnum == soundName);
        s.source.Play();
    }

    public void PlayOneTime(SoundName soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundEnum == soundName);
        s.source.PlayOneShot(s.audioClip);
    }
}

public enum SoundName
{
    ButtonClick,
    CardSet,
    Matched,
    MissMatched
}

[System.Serializable]
public class Sound
{
    public SoundName soundEnum;
    public string soundName;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume;
    [Range(0, 1)] public float pitch;
    public AudioSource source;
}