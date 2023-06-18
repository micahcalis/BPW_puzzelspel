using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private GameObject selfref;
    [SerializeField] private GameObject popupRef;
    private const string playerString = "Player";
    private const string instruct0 = "instruct0";
    private const string instruct1 = "instruct1";
    private const string instruct2 = "instruct2";
    private const string instruct3 = "instruct3";
    private const string code1 = "code1";
    private const string code2 = "code2";
    private const string code3 = "code3";
    private const string code4 = "code4";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerString))
        {
            if (selfref.CompareTag(instruct0))
            {
                popupRef.GetComponent<PopUp>().StartThingy(0);
            }
            if (selfref.CompareTag(instruct1))
            {
                popupRef.GetComponent<PopUp>().StartThingy(1);
            }
            if (selfref.CompareTag(instruct2))
            {
                popupRef.GetComponent<PopUp>().StartThingy(2);
            }
            if (selfref.CompareTag(code1))
            {
                popupRef.GetComponent<PopUp>().StartThingy(3);
            }
            if (selfref.CompareTag(code2))
            {
                popupRef.GetComponent<PopUp>().StartThingy(4);
            }
            if (selfref.CompareTag(code3))
            {
                popupRef.GetComponent<PopUp>().StartThingy(5);
            }
            if (selfref.CompareTag(code4))
            {
                popupRef.GetComponent<PopUp>().StartThingy(6);
            }
            if (selfref.CompareTag(instruct3))
            {
                popupRef.GetComponent<PopUp>().StartThingy(7);
            }
            selfref.gameObject.SetActive(false);
        }
    }
}

