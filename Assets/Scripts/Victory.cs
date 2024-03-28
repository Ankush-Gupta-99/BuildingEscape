using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] AudioSource AS1;
    [SerializeField] AudioSource AS2;
    [SerializeField] AudioSource AS3;
    [SerializeField] AudioSource AS4;
    [SerializeField] AudioSource AS5;
    [SerializeField] AudioSource AS6;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UiManager.instance.gamewin();
            AS1.Stop();
            AS2.Stop();
            AS3.Stop();
            AS4.Stop();
            AS5.Stop();
            AS6.Play();
        }
    }
}
