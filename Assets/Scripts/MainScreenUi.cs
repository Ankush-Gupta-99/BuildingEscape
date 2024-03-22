using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreenUi : MonoBehaviour
{
    [SerializeField] Slider SensSlider;
    [SerializeField] Slider VolumeSlider;
    AudioSource As;
    [SerializeField] Sprite Mute, Unmute;
    [SerializeField] GameObject Main;
    [SerializeField] GameObject setting;/*
    [SerializeField] GameObject Menu;*/
    [SerializeField] Slider LoadingSlider;
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject InstScreen;
    [SerializeField] Image Image;
    [SerializeField]    AudioMixer Volume;
    private void Start()
    {
        As = GetComponent<AudioSource>();
        SetSens(PlayerPrefs.GetFloat("Sens", 0.7f));
        SetVol(PlayerPrefs.GetFloat("Volume", 0));
    }
    public void Exit()
    {
        As.Play();
        Application.Quit();
    }
    public void play()
    {
        As.Play();
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        Main.SetActive(false);
        LoadingScreen.SetActive(true);
        AsyncOperation LevelingLoad = SceneManager.LoadSceneAsync(1);
        while (!LevelingLoad.isDone)
        {
            float prog = Mathf.Clamp01(LevelingLoad.progress / 0.9f);
            LoadingSlider.value = prog - 0.1f;
            yield return null;
        }

    }
    public void mute()
    {
        As.Play();
        if (PlayerPrefs.GetFloat("Volume")>-75)
        {
            PlayerPrefs.SetInt("Volume", -80);
            Volume.SetFloat("Volume", -80);
            VolumeSlider.value = -80;
            Image.sprite = Mute;
        }
        else
        {
            PlayerPrefs.SetInt("Volume", 0);
            Image.sprite = Unmute;
            Volume.SetFloat("Volume", 0);
            VolumeSlider.value = 0;
        }
    }
    public void Setting()
    {
        setting.SetActive(true);
        As.Play();
        Main.SetActive(false);
        float sens = PlayerPrefs.GetFloat("Sens");
        SensSlider.value = sens;
        float vol = PlayerPrefs.GetFloat("Volume");
        VolumeSlider.value = vol;
        if (PlayerPrefs.GetFloat("Volume")>-75)
        {
            Image.sprite = Unmute;
        }
        else
        {
            Image.sprite = Mute;
        }

    }

    
    public void SetSens(float s)
    {
        PlayerPrefs.SetFloat("Sens", s);
    }
    public void SetVol(float v)
    {
        Volume.SetFloat("Volume", v);
        PlayerPrefs.SetFloat("Volume", v);
        Volume.GetFloat("Volume", out float value);
        if (value >= -75)
        {
            Image.sprite = Unmute;
        }
        else
        {
            Image.sprite = Mute;
        }


    }
    public void back()
    {
        As.Play();
        setting.SetActive(false);
        Main.SetActive(true);

    }
    public void iBack()
    {
        As.Play();
        Main.SetActive(true);
        InstScreen.SetActive(false);
    }
    public void iButton()
    {
        As.Play();
        Main.SetActive(false);
        InstScreen.SetActive(true );
    }

}
