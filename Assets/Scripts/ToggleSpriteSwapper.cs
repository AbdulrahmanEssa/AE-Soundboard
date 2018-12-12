using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSpriteSwapper : MonoBehaviour
{
    private Toggle toggle;

    public Sprite spriteOn;
    public Sprite spriteOff;

    public Image checkmarkImage;

    // Use this for initialization
    void Start()
    {
        toggle = GetComponent<Toggle>();

        toggle.toggleTransition = Toggle.ToggleTransition.None;

        toggle.onValueChanged.AddListener(delegate { CalculateSwap(); });

        CalculateSwap();
    }

    public void CalculateSwap()
    {
        if (toggle.isOn)
        {
            checkmarkImage.sprite = spriteOn;
        }
        else
        {
            checkmarkImage.sprite = spriteOff;
        }
    }

    void Update()
    {

    }
}
