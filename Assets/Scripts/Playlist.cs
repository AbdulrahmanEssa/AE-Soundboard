using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Playlist
{
    public string name;
    public List<Sound> sounds;

    public Playlist(string listName)
    {
        name = listName;
    }
}
