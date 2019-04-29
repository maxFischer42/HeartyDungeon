using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 velocity;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = velocity * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = Random.Range(-5.00f, 5.00f);
        float y = Random.Range(-5.00f, 5.00f);
        velocity = new Vector2(x, y);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        float x = Random.Range(-5.00f, 5.00f);
        float y = Random.Range(-5.00f, 5.00f);
        velocity = new Vector2(x, y);
    }
}
