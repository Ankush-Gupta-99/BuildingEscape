using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerEyeHint : MonoBehaviour
{
    [SerializeField] TMP_Text Hint2;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Door"))
        {
            Hint2.SetText("Press E!");
        }
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.gameObject.CompareTag("Door"))
        {
            Hint2.SetText("");
        }
    }
}
