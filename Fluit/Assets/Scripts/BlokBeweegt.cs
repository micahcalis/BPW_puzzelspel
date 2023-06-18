using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokBeweegt : MonoBehaviour
{
    public GameObject blokkie;
    public GameObject noteTrigger;
    [SerializeField] private int distance;
    [SerializeField] private float delay;

    void Start()
    {

    }

    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NoteA"))
        {
            StartCoroutine(MoveRight());
        }
        if (collision.gameObject.CompareTag("NoteB"))
        {
            StartCoroutine(MoveLeft());
        }
        if (collision.gameObject.CompareTag("NoteC"))
        {
            StartCoroutine(MoveUp());
        }
        if (collision.gameObject.CompareTag("NoteD"))
        {
            StartCoroutine(MoveDown());
        }
    }

    IEnumerator MoveRight()
    {
        yield return new WaitForSeconds(delay);
        blokkie.transform.localPosition = new Vector2(blokkie.transform.position.x + distance, blokkie.transform.position.y);
        yield return null;
    }

    IEnumerator MoveLeft()
    {
        yield return new WaitForSeconds(delay);
        blokkie.transform.localPosition = new Vector2(blokkie.transform.position.x - distance, blokkie.transform.position.y);
        yield return null;
    }

    IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(delay);
        blokkie.transform.localPosition = new Vector2(blokkie.transform.position.x, blokkie.transform.position.y + distance);
        yield return null;
    }

    IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(delay);
        blokkie.transform.localPosition = new Vector2(blokkie.transform.position.x, blokkie.transform.position.y - distance);
        yield return null;
    }
}



