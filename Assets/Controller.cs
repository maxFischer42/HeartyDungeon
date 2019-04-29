using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (InputScript))]
[RequireComponent(typeof (AnimationController))]
public class Controller : MonoBehaviour
{
    private InputScript input;
    public float speedMod;
    public float speed = 1f;
    public float attackCooldown = 1f;
    public bool cooldown = false;

    [HideInInspector]
    public Vector2 publicVelocity;

    public bool isAttacking = false;
    public PlayerData playerData;

    public enum directions {Up,Down,Left,Right,UpLeft,DownLeft,UpRight,DownRight};
    [HideInInspector]
    public directions direction;

    public float hitboxOffset = 1f;

    public AudioSource aud;
    public AudioClip sword;

    public void Start()
    {
        input = GetComponent<InputScript>();
    }

    public void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (!isAttacking)
            CheckInputs();
    }

    public GameObject swordHitbox;

    IEnumerator SwordUse()
    {
        bool flipX = GetComponent<SpriteRenderer>().flipX;
        bool flipY = GetComponent<AnimationController>().facingUp;
        aud.PlayOneShot(sword);
        float x = 1;
        float y = -1;
        if (flipX)
            x = -1;
        if (flipY)
            y = 1;
        Vector3 facingDirection = new Vector2(x * hitboxOffset, y * hitboxOffset);
        Vector3 spawnPos = transform.position + facingDirection;
        GameObject hitbox = (GameObject)Instantiate(swordHitbox, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(attackCooldown * 0.6f);
        Destroy(hitbox);
        yield return new WaitForSeconds(attackCooldown * 0.4f);
        isAttacking = false;
    }

    public void CheckInputs()
    {
        
        float x = input.xInput;
        float y = input.yInput;
        float a = input.aInput;
        float b = input.bInput;
        float s = input.startInput;

        if (a > 0 && !cooldown)
        {
            isAttacking = true;
            StartCoroutine(SwordUse());
            return;
        }

        float xVelocity = 0f;
        float yVelocity = 0f;

        if(x != 0)
        {
            xVelocity = x;
        }
        if(y != 0)
        {
            yVelocity = y;
        }
        if(xVelocity != 0 || yVelocity != 0)
        {
            Vector3 velocity = new Vector2(xVelocity, yVelocity);
            Move(velocity);
        }
        publicVelocity = new Vector2(xVelocity, yVelocity);
        
    }

    public void Move(Vector3 di)
    {
        if (di.x == 0 && di.y == 1)
        {
            direction = directions.Up;
        }
        else if (di.x == 0 && di.y == -1)
        {
            direction = directions.Down;
        }
        else if (di.x == 1 && di.y == 0)
        {
            direction = directions.Right;
        }
        else if (di.x == -1 && di.y == 0)
        {
            direction = directions.Left;
        }
        else if (di.x == 1 && di.y == 1)
        {
            direction = directions.UpRight;
        }
        else if (di.x == 1 && di.y == -1)
        {
            direction = directions.DownRight;
        }
        else if (di.x == -1 && di.y == 1)
        {
            direction = directions.UpLeft;
        }
        else if(di.x == -1 & di.y == -1)
        {
            direction = directions.DownLeft;
        }

        transform.position = transform.position + (di * Time.deltaTime * (speedMod +(speed / 2)));
    }

}
