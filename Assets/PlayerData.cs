using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public bool WASD = false;
    public int health = 100;
    public float defense = 1f;
    public float speed = 1f; //cap at 3!!!
    public float swordspeed = 1f;
    public float sworddamage = 1f;
    public float kunaispeed = 1f;
    public float kunaidamage = 1f;
    public int[] priceCatalog = { 25, 25, 25, 25, 25, 25 };
    public int ammo = 10;
    public GameData gameData;
    public int maxlevels = 4;
    public int totaldamage;
    public int totalspent;
    public int totalkills;

    public void Reset()
    {
        health = 250;
        defense = 1f;
        speed = 1f;
        swordspeed = 1f;
        sworddamage = 1f;
        kunaispeed = 1f;
        kunaidamage = 1f;
        priceCatalog = new int[] { 25, 25, 25, 25, 25, 25 };
        ammo = 10;
        gameData.currentLevel = 1;
        totaldamage = 0;
        totalkills = 0;
        totalspent = 0;
    }



}
