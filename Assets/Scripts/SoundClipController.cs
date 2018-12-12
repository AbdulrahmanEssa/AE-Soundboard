using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundClipController : MonoBehaviour
{

    private UIManager UImanager;
    private AudioManager audioManager;

    public string clipName;
    private Sound sound;


    public Toggle loop;
    public Toggle play;
    public Slider timeElapsed;
    public Slider volume;
    public Text clipText;

    private void Start()
    {

        UImanager = UIManager.instance;
        audioManager = AudioManager.instance;
        sound = audioManager.allSounds.Find(s => s.name == clipName);


        // Set the visuals to match the status of the sound
        loop.isOn = sound.loop;
        play.isOn = sound.isPlaying;
        clipText.text = sound.name;
        timeElapsed.maxValue = sound.clip.length;
        volume.value = sound.volume;
        // end

        loop.onValueChanged.AddListener(delegate { OnClickedLoop(); });
        play.onValueChanged.AddListener(delegate { OnClickedPlay(); });
        volume.onValueChanged.AddListener(delegate { OnChangeVolume(); });
    }

    private void Update()
    {
        if (sound.isPlaying)
        {
            timeElapsed.value = sound.GetTimeElapsed();
        }
        else
        {
            play.isOn = false;

            // This is here because of a strange bug or interaction where if you seek, play and the clip ends,
            // the clip plays from the seek time as opposed to from start.
            // this code is very buggy though and prevents the user from seeking to a time near the end of the clip.
            /*if (timeElapsed.value >= timeElapsed.maxValue - timeElapsed.maxValue * 5 / 100)
            {
                sound.Seek(0.0f);
                timeElapsed.value = 0.0001f;
            }*/
        }
    }

    public void OnClickedLoop()
    {
        sound.loop = loop.isOn;
    }

    public void OnClickedPlay()
    {
        if (play.isOn)
            sound.Play();
        else
            sound.Pause();
    }

    // This is part of the buggy code mentioned above.
    public void ResetSeeker()
    {
        timeElapsed.value = 0;
    }

    // This is called by the Seek Slider in the inspector, because you can't AddListener() to OnEndDrag or OnPointerDown
    // And OnValueChanged creates a lot of calls to sound.Seek() because the value is constantly changing in Update()
    public void OnSeek()
    {
        sound.Seek(timeElapsed.value);
        Debug.Log("Seeking...");
    }

    public void OnChangeVolume()
    {
        sound.ChangeVolume(volume.value);
    }

}
