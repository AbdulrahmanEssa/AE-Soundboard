using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistButtonController : MonoBehaviour
{

    private UIManager manager;
    public Playlist playlist;

    private Button button;
    private Text text;


    private void Start()
    {
        manager = UIManager.instance;
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();

        button.onClick.AddListener(OnClicked);
    }


    public void OnClicked()
    {
        manager.ShowPlaylistContent(text.text);
    }
}
