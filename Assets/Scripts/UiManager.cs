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
    public GameObject Particles;
    AudioSource AudioSource;
    public TMP_Text timeer;
    [SerializeField] Animation TimerAnim;
    [SerializeField] AudioSource T_AS;
    int time=300;
    void Start()
    {
        TimerAnim.Stop();
        if(instance == null)
        { 
        instance = this; }
        AudioSource = GetComponent<AudioSource>();  
        Time.timeScale = 1.0f;
        PauseMode.instanse.pause = false;
        StartCoroutine(StartMessage(WelcomeMessage));
        StartCoroutine(Timer());
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (time < 30)
        {
            T_AS.enabled = true;
            TimerAnim.Play();
        }
        if (time < 1||Time.timeScale==0)
        {
            T_AS.enabled=false;
        }
        if (time >=0)
        {
            timeer.SetText(time.ToString());
        }
        else
        {
            gameover();
        }
        if (Input.GetKeyDown(KeyCode.Escape)&&!PauseMode.instanse.pause)
        {
            PauseFunction();
        }
    }
     void gameover()
    {
        Particles.SetActive(true);
        GameOver.SetActive(true);
        Menu.SetActive(false);
        Option.SetActive(false);
        Play.SetActive(false);
        Pause.SetActive(false);
        PauseMode.instanse.pause = true;
        Cursor.lockState = CursorLockMode.None;

    }
    public void gamewin()
    {
        Cursor.lockState = CursorLockMode.None;
        GameWon.SetActive(true );
        GameOver.SetActive(false );
        Menu.SetActive(false);
        Option.SetActive(false);
        Play.SetActive(false);
        Pause.SetActive(false);
        Time.timeScale = 0;
        PauseMode.instanse.pause = true;

    }
    public void PauseFunction()
    {
        AudioSource.Play();
        Play.SetActive(true); 
        Option.SetActive(false);
        Time.timeScale = 0;
        PauseMode.instanse.pause = true;
        PauseSprite.SetActive(true);
        Pause.SetActive(false);
    }
    public void PlayFunction()
    {
        AudioSource.Play();
        Pause.SetActive(true);
        Menu.SetActive(false );
        Time.timeScale = 1.0f;
        PauseMode.instanse.pause = false;
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
        PauseMode.instanse.pause = true;
        Play.SetActive(false);
        Pause.SetActive (false);
    }
    public void ExitFunction()
    {
        AudioSource.Play();
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
    }
    public void RestarFunction()
    {
        AudioSource.Play();
        SceneManager.LoadScene(1);
    }

    IEnumerator StartMessage(GameObject GO)
    {
        GO.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        GO.SetActive(false);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        time--;
        StartCoroutine(Timer());
    }



}
