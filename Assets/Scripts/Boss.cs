using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject Ghoul;
    [SerializeField]AudioSource AS;
    [SerializeField]AudioSource AS2;
    [SerializeField] Keys k;
    bool fire;
    int life=3;
    int i=0;
    [SerializeField] GameObject[] Life;
    [SerializeField]Animation anim;
    [SerializeField] GameObject Sfire;
    void Update()
    {
        if(Time.timeScale>0 && !PauseMode.instanse.pause)
        {
            if (life <= 0)
            {
                StartCoroutine(Dead());
            }
            if (fire && Input.GetKeyDown(KeyCode.Mouse0) && i < 3 && k.gun)
            {
                Sfire.SetActive(true);
                AS.Play();
                life--;
                Life[i].SetActive(false);
                i++;
                StartCoroutine(S());
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AS2.enabled=true;
            fire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AS2.enabled = false;
            fire = false;
        }
    }
    IEnumerator S()
    {
        yield return new WaitForSeconds(0.1f);

        Sfire.SetActive(false);
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        AS.Pause();
        AS2.Pause();
        anim.Play("Death");
        yield return new WaitForSeconds(1f);
        Ghoul.SetActive(false);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
