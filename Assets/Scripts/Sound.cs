using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;

    private AudioSource m_source;
    [HideInInspector]
    public AudioSource source
    {
        get { return m_source; }
        set
        {
            m_source = value;
            value.volume = volume;
            value.clip = clip;
            value.loop = loop;
            value.playOnAwake = false;
            value.pitch = pitch;
        }
    }

    public bool isPlaying
    {
        get { return source.isPlaying; }
    }

    [SerializeField]
    private AudioClip m_clip;
    public AudioClip clip
    {
        get { return m_clip; }
        set
        {
            m_clip = value;
            source.clip = value;
        }
    }

    [SerializeField]
    private float m_volume;
    public float volume
    {
        get { return m_volume; }
        set
        {
            m_volume = value;
            source.volume = value;
        }
    }

    [SerializeField]
    private float m_pitch;
    public float pitch
    {
        get { return m_pitch; }
        set
        {
            m_pitch = value;
            source.pitch = value;
        }
    }

    [SerializeField]
    private bool m_loop;
    public bool loop
    {
        get { return m_loop; }
        set
        {
            m_loop = value;
            source.loop = value;
        }
    }

    public void Play()
    {
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }
    public void Pause()
    {
        source.Pause();
    }
    public void Seek(float seekTime)
    {
        source.time = seekTime;
        Debug.Log("Sound Seeking");
    }
    public float GetTimeElapsed()
    {
        return source.time;
    }
    public void ChangeVolume(float vol)
    {
        volume = vol;
    }

}
