using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalRock : MonoBehaviour
{
    public Transform rock;
    public GameObject noteTrigger;
    [SerializeField] private float _distance;
    [SerializeField] private float delay;
    private float t;
    private bool _moving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NoteA"))
        {
            StartCoroutine(MoveRock(true, _distance));
        }
        if (collision.gameObject.CompareTag("NoteB"))
        {
            StartCoroutine(MoveRock(false, _distance));
        }
    }

    //IEnumerator MoveRight()
    //{
    //    yield return new WaitForSeconds(delay);
    //    rock.transform.localPosition = new Vector2(rock.transform.position.x + distance, rock.transform.position.y);
    //    yield return null;
    //}

    //IEnumerator MoveLeft()
    //{
    //    yield return new WaitForSeconds(delay);
    //    rock.transform.localPosition = new Vector2(rock.transform.position.x - distance, rock.transform.position.y);
    //    yield return null;
    //}

    IEnumerator MoveRock(bool direction, float distance)

    {
        _moving = true;
        Vector3 startPosRock = rock.position;
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            rock.position = Vector3.Lerp(startPosRock, new Vector3(startPosRock.x + (direction ? 1 : -1) * distance, startPosRock.y, 0), t);
            yield return null;
        }
        _moving = false;
        yield return null;
        }
    }
