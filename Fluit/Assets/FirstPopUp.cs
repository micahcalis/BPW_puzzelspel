using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPopUp : MonoBehaviour
{
    public GameObject displayref;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayTutorial());
    }

    // Update is called once per frame
 private IEnumerator PlayTutorial()
    {
        displayref.SetActive(true);
        yield return new WaitForSeconds(7);
        displayref.SetActive(false);
        yield return null;
    }
}
