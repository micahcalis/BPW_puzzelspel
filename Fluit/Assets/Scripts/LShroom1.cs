using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LShroom1 : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    public Sprite Yellow;
    public Sprite Green;
    public Sprite Blue;
    public Sprite Red;
    public Sprite Pink;
    private Sprite currentSprite;
    private const string NOTEA = "NoteA";
    private const string NOTEB = "NoteB";
    private const string NOTEC = "NoteC";
    private const string NOTED = "NoteD";
    public int score;
    public int index;

    private void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(NOTEA))
        {
            currentSprite = Yellow;
            ChangeSprite();
            AddScore();
        }
        if (collision.gameObject.CompareTag(NOTEB))
        {
            currentSprite = Green;
            ChangeSprite();
            AddScore();
        }
        if (collision.gameObject.CompareTag(NOTEC))
        {
            currentSprite = Red;
            ChangeSprite();
            AddScore();
        }
        if (collision.gameObject.CompareTag(NOTED))
        {
            currentSprite = Blue;
            ChangeSprite();
            AddScore();
        }
    }
    private void ChangeSprite()
    {
        SpriteRenderer.sprite = currentSprite;
    }

    IEnumerator OpenNextLevel()
    {
        currentSprite = Pink;
        ChangeSprite();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
       
    }

    private void AddScore()
    {
        if (score >= 3)
        {
            if (currentSprite = Red)
            {
                score = score + 1;
                StartCoroutine(OpenNextLevel());
            }
        }
        else if (score == 2)
        {
            if (currentSprite = Blue)
            {
                score = score + 1;
            }
        }
        else if (score == 1)
        {
            if (currentSprite = Green)
            {
                score = score + 1;
            }
        }
        else if (score == 0)
        {
            if (currentSprite = Green)
            {
                score = score + 1;
            }
        }
        else
        {
            score = 0;
        }

        Debug.Log(score);
    }
}



