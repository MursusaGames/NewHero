using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class SettingMenu : MonoBehaviour
{
    public event Action ChangeSoundSettings;
    public event Action ChangeVibroSettings;
    
    [SerializeField] private Sprite onSound;
    [SerializeField] private Sprite offSound;
    [SerializeField] private Sprite onVibro;
    [SerializeField] private Sprite offVibro;
    [SerializeField] private Image soundBtn;
    [SerializeField] private Image vibroBtn;
    public bool soundOn;
    public bool vibroOn;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 0) soundOn = false;
        else soundOn = true;
        if (PlayerPrefs.GetInt("Vibro") == 0) vibroOn = false;
        else vibroOn = true;
        ChangeSound();
        ChangeVibro();
       
    }
    public void ChangeSoundEvent()
    {
        ChangeSoundSettings?.Invoke();
        soundOn = !soundOn;
        if (PlayerPrefs.GetInt("Sound") == 0) PlayerPrefs.SetInt("Sound",1);
        else PlayerPrefs.SetInt("Sound", 0);
        ChangeSound();
    }
    public void ChangeVibroEvent()
    {
        ChangeVibroSettings?.Invoke();
        vibroOn = !vibroOn;
        if(PlayerPrefs.GetInt("Vibro") == 0) PlayerPrefs.SetInt("Vibro", 1);
        else PlayerPrefs.SetInt("Vibro", 0);
        ChangeVibro();
    }
    private void ChangeSound()
    {
        if (soundOn)
        {
            soundBtn.sprite = onSound;
            soundBtn.color = Color.green;
        }
        else
        {
            soundBtn.sprite = offSound;
            soundBtn.color = Color.red;
        }
    }
    private void ChangeVibro()
    {
        if (vibroOn)
        {
            vibroBtn.sprite = onVibro;
            vibroBtn.color = Color.green;
        }
        else
        {
            vibroBtn.sprite = offVibro;
            vibroBtn.color = Color.red;
        }
    }
}
