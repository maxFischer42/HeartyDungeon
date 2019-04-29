using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public GameObject kunaiObject;
    public float throwSpeed = 1;
    public float cooldown = 1f;
    public bool cooling = false;
    public AudioSource aud;
    public AudioClip clip;
    public PlayerData data;


    public void Update()
    {
        if(Input.GetMouseButton(1) && data.ammo > 0 && !cooling)
        {
            aud.PlayOneShot(clip);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 velocity = mousePos - transform.position;
            velocity.Normalize();
            GameObject newKunai = Instantiate(kunaiObject, transform.position,Quaternion.identity);
            newKunai.GetComponent<Rigidbody2D>().velocity = velocity * throwSpeed;

            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            
            Debug.Log(angle);
            angle -= 25f;
            newKunai.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            StartCoroutine(Cool());
            data.ammo--;
        }
    }

    public IEnumerator Cool()
    {
        cooling = true;
        yield return new WaitForSeconds(cooldown);
        cooling = false;
    }
}
