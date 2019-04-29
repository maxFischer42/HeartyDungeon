using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHolder : MonoBehaviour
{
    public Enemy referenceEnemy;
    public int damage = 1;

    private void Start()
    {
        if (referenceEnemy)
            damage = referenceEnemy.damage;
    }
}
