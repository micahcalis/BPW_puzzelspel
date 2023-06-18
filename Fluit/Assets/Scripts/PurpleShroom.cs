using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PurpleShroom : MonoBehaviour
{
    public Transform shroom;
    public int index;
    [SerializeField] private float _distance;
    private int upDown;

    private float currentHeight;
    private float t = 0f;
    private bool _moving;
    private const string NOTEC = "NoteC";
    private const string NOTED = "NoteD";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(NOTEC))
        {
            if (index >= 2 || _moving)
                return;
            index = math.min(2, index + 1);
            StartCoroutine(MoveShroom(true, _distance));
        }
        if (collision.gameObject.CompareTag(NOTED))
        {
            if (index <= 0 || _moving)
                return;
            index = math.max(0, index - 1);
            StartCoroutine(MoveShroom(false, _distance));
        }
    }


    IEnumerator MoveShroom(bool shouldGoUp, float distance)

    {
        _moving = true;
        Vector3 startPosShroom = shroom.position;
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            shroom.position = Vector3.Lerp(startPosShroom, new Vector3(startPosShroom.x, startPosShroom.y + (shouldGoUp ? 1 : -1) * distance, 0), t);
            yield return null;
        }
        _moving = false;
        yield return null;

    }
}

