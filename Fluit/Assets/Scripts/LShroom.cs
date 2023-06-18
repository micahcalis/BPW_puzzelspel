using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LShroom : MonoBehaviour
{
    [SerializeField] private AudioClip victoryclip;
    [SerializeField] private AudioSource source;
    private SpriteRenderer SpriteRenderer;
    [SerializeField] private Sprite Yellow;
    [SerializeField] private Sprite Green;
    [SerializeField] private Sprite Blue;
    [SerializeField] private Sprite Red;
    [SerializeField] private Sprite Pink;
    private Sprite Original;
    private const string NOTEA = "NoteA";
    private const string NOTEB = "NoteB";
    private const string NOTEC = "NoteC";
    private const string NOTED = "NoteD";
    private int currentscore = 0;
    public int codeJ;
    public int codeK;
    public int codeL;
    public int codeSemi;
    private int currentScene;

    private void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Original = SpriteRenderer.sprite;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 2)
        {
            currentScene = -1;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(NOTEA))
        {
            ChangeSprite(Yellow);
            AddScore(codeJ);
        }
        if (collision.gameObject.CompareTag(NOTEB))
        {
            ChangeSprite(Green);
            AddScore(codeK);
        }
        if (collision.gameObject.CompareTag(NOTEC))
        {
            ChangeSprite(Red);
            AddScore(codeL);
        }
        if (collision.gameObject.CompareTag(NOTED))
        {
            ChangeSprite(Blue);
            AddScore(codeSemi);
        }
    }
    private void ChangeSprite(Sprite currentSprite)
    {
        SpriteRenderer.sprite = currentSprite;
    }

    IEnumerator OpenNextLevel()
    {
        ChangeSprite(Pink);
        source.PlayOneShot(victoryclip);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(currentScene + 1);
    }

    private void AddScore(int currentcode)
    {
        if (currentscore == currentcode)
        {
            currentscore = currentscore + 1;
            Debug.Log(currentscore);
            if (currentscore == 4)
            {
                StartCoroutine(OpenNextLevel());
            }
        }
        else
        {
            currentscore = 0;
            ChangeSprite(Original);
        }
    }
}



