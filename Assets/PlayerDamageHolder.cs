using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHolder : MonoBehaviour
{
    public PlayerData data;
    public int damage;
    public bool isKunai;
    public AudioClip clip;
    private void Start()
    {
        if(!isKunai)
        damage = (int)data.sworddamage;
        else
        damage = 3 + (int)(1.5 * data.kunaidamage);
    }
}
