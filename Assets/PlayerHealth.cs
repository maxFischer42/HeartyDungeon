using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData data;
    public Controller controller;
    public Kunai kunai;
    public Image fadeout;
    public float timeToDed = 4f;
    public bool isDed; //cathy was here
    bool fad;
    public bool win;
    public AudioClip clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyDamageHolder>())
        {
            data.health -= collision.gameObject.GetComponent<EnemyDamageHolder>().damage;
            data.totaldamage += collision.gameObject.GetComponent<EnemyDamageHolder>().damage;
            Vector3 push = transform.position - collision.gameObject.transform.position;
            GetComponent<Rigidbody2D>().AddForce(push * collision.gameObject.GetComponent<EnemyDamageHolder>().damage);
            StartCoroutine(colorChange());
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyDamageHolder>())
        {
            data.health -= collision.gameObject.GetComponent<EnemyDamageHolder>().damage - (1 * (int)data.defense);
            data.totaldamage += collision.gameObject.GetComponent<EnemyDamageHolder>().damage;
            Vector3 push = transform.position - collision.gameObject.transform.position;
            GetComponent<Rigidbody2D>().AddForce(push * collision.gameObject.GetComponent<EnemyDamageHolder>().damage);
            StartCoroutine(colorChange());
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }

    public void Update()
    {
        if (data.health <= 0 || win)
        {
            Camera.main.GetComponent<AudioSource>().enabled = false;
            if(!win)
                isDed = true;
            controller.enabled = false;
            kunai.enabled = false;
            Color color = fadeout.color;
            color.a += 0.01f;
            // Debug.Log(color.a);
            fadeout.color = color;
            if(!fad)
            {
                fad = true;
                StartCoroutine(Fade());
            }
        }
    }
    
    public IEnumerator Fade()
    {        
        yield return new WaitForSeconds(timeToDed);
        Debug.Log("dead");
        if (!win)
        {
            data.Reset();
            if (data.loopLevel)
            {
                SceneManager.LoadScene("Procedural");
            }
            else
            SceneManager.LoadScene("Menu");
            
        }
        else if (win)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    public Color defaultColor;
    public Color hurtColor;
    public float lengthHurt;

    public IEnumerator colorChange()
    {
        SpriteRenderer sprt = GetComponent<SpriteRenderer>();
        sprt.color = hurtColor;
        yield return new WaitForSeconds(lengthHurt);
        sprt.color = defaultColor;
    }


}
