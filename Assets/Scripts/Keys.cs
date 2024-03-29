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
    public int gunpart;
    [SerializeField] TMP_Text Hint;
    [SerializeField] TMP_Text Hint2;
    [SerializeField] TMP_Text Hint3;
    bool flag;
    GameObject it;
    AudioSource audioSource;
    public string[] HintClip = new string[4];
    public bool gun;
    [SerializeField] GameObject Gun;
    [SerializeField] GameObject GunText;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.timeScale > 0 && !PauseMode.instanse.pause)
        {

            if (Input.GetKeyUp(KeyCode.R) && gunpart >= 3)
            {
                Gun.SetActive(true);
                gun = true;
                GunText.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Q) && flag)
            {
                audioSource.Play();
                KeyCollected[i++] = it.name;
                if (it.name == "Double Barrel Gun Part-1" || it.name == "Double Barrel Gun Part-2" || it.name == "Bullet of Double Barrel Gun")
                {
                    gunpart++;
                    if (gunpart >= 3)
                    {
                        StartCoroutine(GunTextCo());
                    }
                }
                flag = false;
                if (it.name == "Clipboard" && j <= HintClip.Length)
                {
                    StartCoroutine(ClipDest());
                }

                StartCoroutine(ItemsDest(it));
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barr1")&&!gun)
        {
            Hint.SetText("Activate gun before going to roof.");
        }
        if (other.gameObject.CompareTag("Barr1")&&gun)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Boss")&&gun)
        {
            StartCoroutine(FireText());
        }
        if (other.gameObject.CompareTag("Items"))
        {
            flag = true;
        }
    }
    private void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.CompareTag("Items"))
        {
            Hint.SetText("You have found " + hit.gameObject.name + ": press Q to collect.");
            it = hit.gameObject;

        }
    }
    void OnTriggerExit(Collider x)
    {
        if (x.gameObject.CompareTag("Barr1"))
        {
            Hint.SetText("");
        }
        if (x.gameObject.CompareTag("Boss"))
        {
            Hint.SetText("");
        }
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
    IEnumerator GunTextCo()
    {
        yield return new WaitForSeconds(1);
        GunText.SetActive(true);
        yield return new WaitForSeconds(5);
        GunText.SetActive(false);
    }

    IEnumerator ClipDest()
    {

        yield return new WaitForSeconds(0.6f);
        Hint3.SetText(HintClip[j++]);
        yield return new WaitForSeconds(5);
        Hint3.SetText("");
    }
    IEnumerator FireText()
    {
        Hint.SetText("Fire");
        yield return new WaitForSeconds(5);
        Hint.SetText("");

    }

}
