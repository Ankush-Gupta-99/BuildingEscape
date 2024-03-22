using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class teleport : MonoBehaviour
{
    [SerializeField] Transform tel;

    [SerializeField] TMP_Text Hint;
    Collider pla;
    bool flag;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&flag)
        {
            flag = false;
            pla.gameObject.transform.localPosition = tel.localPosition;
            pla.gameObject.transform.localScale = tel.localScale;
            Hint.SetText("");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Hint.SetText("Press E to teleport.");
            pla = other;
            flag= true;
        }
    }
    void OnTriggerExit(Collider x)
    {
        if (x.gameObject.CompareTag("Player"))
        {
            Hint.SetText("");
            flag = false;

        }

    }

}
