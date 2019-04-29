using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    public float deathTime = 3f;
    public Transform shootpos;
    public float cooldown;
    public bool cool = true;
    public AudioClip shootClip;
    public AudioSource aud;
    public float maxDistance = 6f;

    private void Awake()
    {
        StartCoroutine(Cooldown());
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GameObject.Find("Player").transform.position - transform.position;
        if (direction.magnitude > maxDistance)
            return;
        if(!cool)
        {
            aud.PlayOneShot(shootClip);
            GameObject _projectile = (GameObject)Instantiate(projectile,shootpos);
            _projectile.transform.parent = null;
            Vector2 velocity = GameObject.Find("Player").transform.position - transform.position;
            velocity.Normalize();
            _projectile.GetComponent<Rigidbody2D>().velocity = velocity * speed;
            Destroy(_projectile, deathTime);
            StartCoroutine(Cooldown());
        }
    }

    public IEnumerator Cooldown()
    {
        cool = true;
        yield return new WaitForSeconds(cooldown);
        cool = false;
    }
}
