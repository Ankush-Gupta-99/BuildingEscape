using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnder : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerEye"))
        {
            Debug.Log("Display HideUnder Button and freeze Movement of player");
        }
    }
}
