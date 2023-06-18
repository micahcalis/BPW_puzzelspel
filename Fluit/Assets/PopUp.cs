using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject instructStart;
    [SerializeField] private GameObject instruct2;
    [SerializeField] private GameObject instruct3;
    [SerializeField] private GameObject instruct4;
    [SerializeField] private GameObject code1;
    [SerializeField] private GameObject code2;
    [SerializeField] private GameObject code3;
    [SerializeField] private GameObject code4;
    [SerializeField] private GameObject image;
    void Start()
    {
        instructStart.SetActive(false);
        instruct2.SetActive(false);
        instruct3.SetActive(false);
        instruct4.SetActive(false);
        code1.SetActive(false); 
        code2.SetActive(false); 
        code3.SetActive(false); 
        code4.SetActive(false); 
        image.SetActive(false);
    }
    private IEnumerator ActivateScroll(bool ShowImage, GameObject currentMessage)
    {
        currentMessage.SetActive(true);
        if (ShowImage)
        {
            image.SetActive(true);
        }
        yield return new WaitForSeconds(3);
        currentMessage.SetActive(false);
        if (ShowImage)
        {
            image.SetActive(false);
        }
        yield return null;
    }

    public void StartThingy(int index)
    {
        switch (index)
        {
            case 0:
                StartCoroutine(ActivateScroll(false, instructStart));
                break;
            case 1:
                StartCoroutine(ActivateScroll(true, instruct2));
                break;
            case 2:
                StartCoroutine(ActivateScroll(true, instruct3));
                break;
            case 3:
                StartCoroutine(ActivateScroll(true, code1));
                break;
            case 4:
                StartCoroutine(ActivateScroll(true, code2));
                break;
            case 5:
                StartCoroutine(ActivateScroll(true, code3));
                break;
            case 6:
                StartCoroutine(ActivateScroll(true, code4));
                break;
            case 7:
                StartCoroutine(ActivateScroll(true, instruct4));
                break;
        }
    }
}

