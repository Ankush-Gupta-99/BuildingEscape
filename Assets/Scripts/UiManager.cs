//using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    // Start is called before the first frame update
    public GameObject Menu;
    public GameObject Option;
    public GameObject Play;
    public GameObject Pause;
    public GameObject PauseSprite;
    public GameObject WelcomeMessage;
    public GameObject GameOver;
    public GameObject GameWon;
    AudioSource AudioSource;
    public TMP_Text timeer;
    int time=300;
    void Start()
    {
        if(instance == null)
        { 
        instance = this; }
        AudioSource = GetComponent<AudioSource>();  
        Time.timeScale = 1.0f;
        StartCoroutine(StartMessage(WelcomeMessage));
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    private void Update()
    {
        if (time >=0)
        {
            timeer.SetText(time.ToString());
        }
        else
        {
            gameover();
        }
    }
     void gameover()
    {
        GameOver.SetActive(true);
        Menu.SetActive(false);
        Option.SetActive(false);
        Play.SetActive(false);
        Pause.SetActive(false);
        Time.timeScale = 0;

    }
    public void gamewin()
    {
        GameWon.SetActive(true );
        GameOver.SetActive(false );
        Menu.SetActive(false);
        Option.SetActive(false);
        Play.SetActive(false);
        Pause.SetActive(false);

        Time.timeScale = 0;

    }
    public void PauseFunction()
    {
        AudioSource.Play();
        Play.SetActive(true); 
        Option.SetActive(false);
        Time.timeScale = 0;
        PauseSprite.SetActive(true);
        Pause.SetActive(false);
    }
    public void PlayFunction()
    {
        AudioSource.Play();
        Pause.SetActive(true);
        Menu.SetActive(false );
        Time.timeScale = 1.0f;
        Option.SetActive(true);
        PauseSprite.SetActive(false);
        Play.SetActive(false);
    }
    public void MenuFunction()
    {
        AudioSource.Play();
        Menu.SetActive(true);
        Option.SetActive(false);
        Time.timeScale = 0;
        Play.SetActive(false);
        Pause.SetActive (false);
    }
    public void ExitFunction()
    {
        AudioSource.Play();
        SceneManager.LoadScene(0);
    }
    public void RestarFunction()
    {
        AudioSource.Play();
        SceneManager.LoadScene(1);
    }

    IEnumerator StartMessage(GameObject GO)
    {
        GO.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        GO.SetActive(false);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        time--;
        StartCoroutine(Timer());
    }



}
