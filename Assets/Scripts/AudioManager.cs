using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public List<Playlist> playlists = new List<Playlist>();
    [HideInInspector]
    public List<Sound> allSounds = new List<Sound>();

    private void Awake()
    {
        foreach (Playlist list in playlists)
        {
            foreach (Sound s in list.sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                allSounds.Add(s);
            }
        }
    }

    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Play(string clipName)
    {
        Sound s = allSounds.Find(sound => sound.name == clipName);
        s.source.Play();

    }

    public void Stop(string clipName)
    {
        Sound s = allSounds.Find(sound => sound.name == clipName);
        {
            s.source.Stop();
        }
    }

    public Playlist GetPlaylist(string playlistName)
    {
        Playlist list = playlists.Find(playlist => playlist.name == playlistName);
        return list;
    }
}
