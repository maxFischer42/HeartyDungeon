using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;
    public void Update()
    {
        Vector2 dir = GameObject.Find("Player").transform.position - transform.position;
        rig.AddForce(dir.normalized);
        rig.velocity = (dir * speed);
    }
}
