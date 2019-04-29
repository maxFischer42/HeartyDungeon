using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public int damage;
    public int health;
    public GameObject reward;
}
