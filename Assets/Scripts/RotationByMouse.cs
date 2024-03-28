using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationByMouse : MonoBehaviour
{
    [SerializeField] Transform Camera;
    float xrot;
    bool Mlock;
    [SerializeField]float S;
    private void Awake()
    {
        S = PlayerPrefs.GetFloat("Sens");
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (!Mlock)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Mlock = true;

            }
        }
        if (Mlock)
        {
            float X = Input.GetAxis("Mouse X") * Time.deltaTime * 1000 * S;
            float Y = Input.GetAxis("Mouse Y") * Time.deltaTime * 300 *S ;
            xrot -= Y;
            xrot = Mathf.Clamp(xrot, -30, 50);
            Quaternion rota = Quaternion.Euler(transform.up * X);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(transform.localRotation.eulerAngles + rota.eulerAngles), 0.1f);
            //transform.Rotate(transform.up * X);
            Camera.localRotation = Quaternion.Lerp(Camera.localRotation, Quaternion.Euler(xrot, 0, 0), 0.9f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Mlock = false;

        }


    }
}
