using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Keys : MonoBehaviour
{
    public string[] KeyCollected = new string[10];
    int i = 0;
    int j = 0;
    [SerializeField] TMP_Text Hint;
    [SerializeField] TMP_Text Hint2;
    bool flag;
    GameObject it;
    AudioSource audioSource;
    public string[] HintClip = new string[4];
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && flag)
        {
            audioSource.Play();
            KeyCollected[i++] = it.name;
            flag = false;
            if (it.name == "Clipboard" && j <= HintClip.Length)
            {
                StartCoroutine(ClipDest());
            }

            StartCoroutine(ItemsDest(it));
        }
    }

    IEnumerator ClipDest()
    {

        yield return new WaitForSeconds(0.6f);
        Hint2.SetText(HintClip[j++]);
        yield return new WaitForSeconds(5);
        Hint2.SetText("");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Items"))
        {
            flag = true;
        }
    }
    private void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.CompareTag("Items"))
        {
            if (Hint2.text != "")
            {
                Hint2.SetText("");
            }
            Hint.SetText("You have found " + hit.gameObject.name + ": press E");
            it = hit.gameObject;

        }
    }
    void OnTriggerExit(Collider x)
    {
        if (x.gameObject.CompareTag("Items"))
        {
            Hint.SetText("");
            flag = false;

        }

    }

    IEnumerator ItemsDest(GameObject hit)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(hit);
        Hint.SetText("");
    }

}
