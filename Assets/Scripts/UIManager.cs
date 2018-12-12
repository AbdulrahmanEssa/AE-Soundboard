using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    private AudioManager audioManager;

    [Header("Prefabs")]
    public GameObject clipUIPrefab;
    public GameObject playlistUIPrefab;

    [Space]
    [Header("Scroll View Panels")]
    public GameObject playlistPanel;
    public GameObject clipsPanel;

    [Space]
    [Header("Grouping Objects")]
    public GameObject playlistGroup;
    public GameObject soundGroup;



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


        audioManager = AudioManager.instance;

        foreach (Playlist list in audioManager.playlists)
        {
            GameObject locButton = Instantiate(playlistUIPrefab, new Vector3(0, 0, 0),
                                               Quaternion.Euler(Vector3.zero),
                                               playlistGroup.transform);
            locButton.GetComponentInChildren<Text>().text = list.name;
            locButton.GetComponent<PlaylistButtonController>().playlist = list;

        }
    }


    public void ShowPlaylistContent(string playlistName)
    {
        playlistPanel.SetActive(false);
        clipsPanel.SetActive(true);
        Playlist playlist = audioManager.GetPlaylist(playlistName);
        foreach (Sound s in playlist.sounds)
        {
            GameObject soundButton = Instantiate(clipUIPrefab, new Vector3(0, 0, 0),
                                                 Quaternion.Euler(Vector3.zero),
                                                 soundGroup.transform);
            soundButton.GetComponent<SoundClipController>().clipName = s.name;
        }
    }

    public void BackToPlaylistsView()
    {
        foreach (Transform tf in soundGroup.GetComponentsInChildren<Transform>())
        {
            if (tf.gameObject != soundGroup)
                Destroy(tf.gameObject);
        }
        clipsPanel.SetActive(false);
        playlistPanel.SetActive(true);

    }

}
