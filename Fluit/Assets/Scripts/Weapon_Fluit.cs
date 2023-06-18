using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Weapon_Fluit : MonoBehaviour
{
    [SerializeField] private Transform fPoint;
    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject bullet2;
    [SerializeField] private GameObject bullet3;
    [SerializeField] private GameObject bullet4;
    [SerializeField] private float time;
    [SerializeField] private float fireRate;
    private GameObject noteType;
    public AudioSource flute;
    public AudioClip noteA;
    public AudioClip noteB;
    public AudioClip noteC;
    public AudioClip noteD;
    private AudioClip noteSound;
    public int Ammo;
    private bool canChange = true;
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetButtonDown("Note1")) 
        {
            if (canChange == true)
            {
                noteType = bullet1;
            }
            noteSound = noteA;
            canChange = false;
            StartCoroutine(Shoot());
        }
        if (Input.GetButtonDown("Note2"))
        {
            if (canChange == true)
            {
                noteType = bullet2;
            }
            noteSound = noteB;
            canChange = false;
            StartCoroutine(Shoot());
        }
        if (Input.GetButtonDown("Note3"))
        {
            if (canChange == true)
            {
                noteType = bullet3;
            }
            noteSound = noteC;
            canChange = false;
            StartCoroutine(Shoot());
        }
        if (Input.GetButtonDown("Note4"))
        {
            if (canChange == true)
            {
                noteType = bullet4;
            }
            noteSound = noteD;
            canChange = false;
            StartCoroutine(Shoot());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    IEnumerator Shoot()
    {
        if (Ammo == 0)
        {
            canShoot = false;
        }
        if (canShoot == true)
        {
            canShoot = false;
            flute.PlayOneShot(noteSound);
            GameObject newBullet = Instantiate(noteType, fPoint.position, fPoint.rotation);
            CircleCollider2D c3 = newBullet.GetComponent<CircleCollider2D>();
            newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * transform.localScale.x, newBullet.transform.localScale.y);
            newBullet.GetComponent<NoteScript>().SetPlayerV(transform);

            yield return new WaitForSeconds(time);

            GameObject newBullet2 = Instantiate(noteType, fPoint.position, fPoint.rotation);
            CircleCollider2D c = newBullet2.GetComponent<CircleCollider2D>();
            c.enabled = false;
            newBullet2.transform.localScale = new Vector2(newBullet2.transform.localScale.x * transform.localScale.x, newBullet2.transform.localScale.y);
            newBullet2.GetComponent<NoteScript>().SetPlayerV(transform);
            yield return new WaitForSeconds(time);

            GameObject newBullet3 = Instantiate(noteType, fPoint.position, fPoint.rotation);
            CircleCollider2D c2 = newBullet3.GetComponent<CircleCollider2D>();
            c2.enabled = false;
            newBullet3.transform.localScale = new Vector2(newBullet3.transform.localScale.x * transform.localScale.x, newBullet3.transform.localScale.y);
            newBullet3.GetComponent<NoteScript>().SetPlayerV(transform);
            yield return new WaitForSeconds(fireRate * Time.deltaTime);
            Ammo = Ammo - 1;

            canChange = true;
            canShoot = true;
 
        }
   
    }

}
