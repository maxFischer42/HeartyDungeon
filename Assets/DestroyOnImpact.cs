using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerDamageHolder>())
        {
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(collision.gameObject.GetComponent<PlayerDamageHolder>().clip);
        }
        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
