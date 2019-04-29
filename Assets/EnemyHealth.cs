using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public Enemy myEnemy;
    public int hp;
    private int mHP;
    public AudioSource aud;
    public AudioClip hurtclip;
    public AudioClip deathclip;
    public Scrollbar healthbar;
    public bool isBoss;
    public bool pot;
    public GameObject bossObjects;
    public RuntimeAnimatorController deathAnimation;
    public Animator bossAnim;

    private void Start()
    {
        hp = myEnemy.health;
        if(GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel > 1 && !pot)
            hp = hp + Mathf.RoundToInt(GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel * 2.5f);
        mHP = hp;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerDamageHolder>())
        {
            hp -= collision.gameObject.GetComponent<PlayerDamageHolder>().damage;
            StartCoroutine(colorChange());
            if (hp <= 0)
            {
                GameObject.Find("Player").GetComponent<Controller>().playerData.totalkills++;
                if (!isBoss)
                {
                    GameObject prize = (GameObject)Instantiate(myEnemy.reward, transform);
                    prize.gameObject.GetComponent<AudioSource>().PlayOneShot(deathclip);
                    prize.transform.parent = null;
                    Destroy(gameObject);
                }
                else
                {
                    GameObject.Find("Player").GetComponent<PlayerHealth>().win = true;
                    Destroy(bossObjects);
                    StartCoroutine(delayDeath());
                }
            }
            else
            {
                aud.PlayOneShot(hurtclip);
            }
        }
    }

    public IEnumerator delayDeath()
    {
        bossAnim.speed = 0.4f;
        bossAnim.runtimeAnimatorController = deathAnimation;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public Color defaultColor;
    public Color hurtColor;
    public float lengthHurt;

    public IEnumerator colorChange()
    {
        float currentHP = hp;
        float maxHp = mHP;
        float newhp = currentHP / maxHp;
        if(healthbar)
            healthbar.size = newhp;

        Debug.Log("maxhp: " + mHP + "    hp: " + hp);
        SpriteRenderer sprt = GetComponent<SpriteRenderer>();
        sprt.color = hurtColor;
        yield return new WaitForSeconds(lengthHurt);
        sprt.color = defaultColor;
    }
}
