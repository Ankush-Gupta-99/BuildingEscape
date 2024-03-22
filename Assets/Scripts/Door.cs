using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        AS.playOnAwake = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerEye"))
        {
            player = true;
            
        }
    }  private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerEye"))
        {
            player = false;
            
        }
    }


    void Update()
    {
        foreach ( string k in keys.KeyCollected)
        {
            if(k == key&&key!="")
            {
                DoorLock = false;
            }
        }
        if (player && Input.GetKeyDown(KeyCode.Space) && !DoorLock)
        {

            AS.Play();
            if (!doorBool)
                doorBool = true;
            else
                doorBool = false;
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
