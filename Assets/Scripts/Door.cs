using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 OpenRotation, CloseRotation;
    public float rotSpeed = 1f;
    bool player;
    public bool doorBool;
    public bool DoorLock;
    [SerializeField] string key;
    [SerializeField] Keys keys;
    AudioSource AS;

    [SerializeField] GameObject LockText;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        AS.playOnAwake = false;
    }


    void Update()
    {
        if (Time.timeScale > 0)
        {

            foreach (string k in keys.KeyCollected)
            {
                if (k == key && key != "")
                {
                    DoorLock = false;
                }
            }
            if (player && Input.GetKeyDown(KeyCode.E) && !DoorLock)
            {
                //StartCoroutine(Pause());
                AS.Play();
                if (!doorBool)
                    doorBool = true;
                else
                    doorBool = false;
            }
            else if (player && Input.GetKeyDown(KeyCode.E) && DoorLock)
            {
                LockText.SetActive(true);
                StartCoroutine("DLockTex");
            }
            if (doorBool && !DoorLock)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(OpenRotation), rotSpeed * Time.deltaTime);


            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CloseRotation), rotSpeed * Time.deltaTime);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerEye"))
        {
            player = true;
            
        }
    } 
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerEye"))
        {
            player = false;
            
        }
    }

    /* IEnumerator Pause()
     {
         PauseMode.instanse.pause=true;
         yield return new WaitForSeconds(1.2f);
         PauseMode.instanse.pause = false;
     }*/
    IEnumerator DLockTex()
    {
        yield return new WaitForSeconds(1);

        LockText.SetActive(false);
    }
}
