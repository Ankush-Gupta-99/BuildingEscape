using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] Animator animator;
    [Header("Velocity Multiplier")]
    public float speed;
    [Header("Camera")][SerializeField] Transform Cam;
    float Ycamera;
    bool sit;
    [SerializeField] Vector3 Gravity=new Vector3(0,-10,0);
    [SerializeField] AudioSource AS;
    [SerializeField] AudioSource AS2;
    int sprint;
    private void Awake()
    {
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();
        controller.enableOverlapRecovery = true;
    }
    private void Start()
    {
        Ycamera = Cam.transform.localPosition.y;
    }
    private void Update()
    {
        if (Time.timeScale > 0 && !PauseMode.instanse.pause)
        {
            Movem();
            Crouch();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                sprint = 4;
            }
            else
            {
                sprint = 2;
            }
        }
    }

    void Crouch()
    { 

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (sit == false)
            {
                sit = true;
                controller.height = 0.5f;
                controller.center =new  Vector3(0, 0.7f, 0);
                Cam.localPosition = Cam.localPosition + new Vector3(0, -2, 0);
                
            }
            else
            {
                sit = false;
                controller.height = 3.5f;
                controller.center = new Vector3(0, 1.5f, 0);
                Cam.localPosition = new Vector3(Cam.localPosition.x, Ycamera, Cam.localPosition.z);
                
            }
        }
    }
    void Movem()
    {
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");


        if (X != 0 || Y != 0)
        {
            AS.enabled = true;
            AS2.enabled = true;
            controller.Move((((transform.forward * Y + transform.right * X).normalized *sprint* speed) + (Gravity)) * Time.deltaTime);
            animator.SetBool("Wait", false);
            animator.SetBool("Walk", true);
        }
        else
        {
            AS.enabled= false;
            AS2.enabled= false;
            animator.SetBool("Wait", true);
            animator.SetBool("Walk", false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Colidable"))
        {
            hit.rigidbody.AddForce(transform.forward * 5, ForceMode.Impulse);
            hit.rigidbody.useGravity = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.name== "OnlyCrouch")
        {
            if (sit == false)
            {
                sit = true;
                controller.height = 0.5f;
                controller.center = new Vector3(0, 0.7f, 0);
                Cam.localPosition = Cam.localPosition + new Vector3(0, -2, 0);

            }
        }
    }

}
