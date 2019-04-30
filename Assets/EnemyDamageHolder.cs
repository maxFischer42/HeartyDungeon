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
        {
            if(GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel > 1)
            {
            damage = referenceEnemy.damage * GameObject.Find("LevelGenerator").GetComponent<GameData>().currentLevel;

            }else
            {
                damage = referenceEnemy.damage;
            }

        }
    }
}
