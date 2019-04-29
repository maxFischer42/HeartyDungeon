using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioClip clip;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Controller>().playerData.health++;
            GameObject.Find("Player").GetComponent<AudioSource>().PlayOneShot(clip);
            Destroy(gameObject);
        }
    }
}
