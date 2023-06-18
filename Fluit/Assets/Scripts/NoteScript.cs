using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public float bSpeed = 40f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float noteGrowthRate;
    [SerializeField] private Transform Note;
    [SerializeField] private GameObject NotePrefab;
    [SerializeField] private float maxSize;
    private Transform PlayerV;

    void Start()
    {
        rb.velocity = transform.right * bSpeed * transform.localScale.x;
        StartCoroutine(ScaleUp(5, (transform.right * transform.localScale.x).x < 0));
    }


    void Update()
    {
        if (Note.localScale.y > maxSize)
        {
            Destroy(NotePrefab);
        }
    }

    public void SetPlayerV(Transform t)
    {
        PlayerV = t;
    }

    private IEnumerator ScaleUp(float maxScale, bool invert)
    {
        while (true)
        {
            if (PlayerV.localScale.x > 0)
            {
                rb.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(maxScale, maxScale, maxScale), noteGrowthRate * Time.deltaTime);
                if (rb.transform.localScale.x == maxScale)
                {
                    break;
                }
            }
            if (PlayerV.localScale.x < 0)
            {
                rb.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-maxScale, maxScale, maxScale), noteGrowthRate * Time.deltaTime);
                if (rb.transform.localScale.x == -maxScale)
                {
                    break;
                }
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
