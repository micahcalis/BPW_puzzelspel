using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ammo : MonoBehaviour
{
    private Weapon_Fluit weaponFluit;
    public GameObject playerref;
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        weaponFluit = playerref.GetComponent<Weapon_Fluit>();
    }
    void Update()
    {
        ammoText.text = weaponFluit.Ammo.ToString();
    }
}
