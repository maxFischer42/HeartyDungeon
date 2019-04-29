using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class AnimationController : MonoBehaviour
{
    public RuntimeAnimatorController Idle;
    public RuntimeAnimatorController WalkDown;
    public RuntimeAnimatorController WalkUp;
    public RuntimeAnimatorController AttackDown;
    public RuntimeAnimatorController AttackUp;
    public RuntimeAnimatorController dead;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Controller controller;
    public PlayerData pdata;
    private PlayerHealth hp;
    public bool facingUp;

    private void Start()
    {
        controller = GetComponent<Controller>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hp = GetComponent<PlayerHealth>();
    }

    public void Update()
    {
        if(hp.isDed)
        {
            animator.speed = 0.26f;
            animator.runtimeAnimatorController = dead;
            return;
        }
        Vector2 velocity = controller.publicVelocity;
        //check for x flip
        FlipX(velocity.x);
        //check for y flip
        CheckUp(velocity.y);
        if(controller.isAttacking)
        {
            AttackAnims();
            return;
        }
        animator.speed = 1;
        if(velocity.x != 0 || velocity.y != 0)
        {
            MoveAnims();
            return;
        }

        CheckForIdle();
    }

    void MoveAnims()
    {
        if (facingUp)
        {
            animator.runtimeAnimatorController = WalkUp;
        }
        else
        {
            animator.runtimeAnimatorController = WalkDown;
        }
    }

    void AttackAnims()
    {
        if(facingUp)
        {
            animator.runtimeAnimatorController = AttackUp;
            if(pdata.swordspeed > 1)
            {
                animator.speed = 1 + (0.1f*pdata.swordspeed);
            }
            else
            {
                animator.speed = 1;
            }
        }
        else
        {
            animator.runtimeAnimatorController = AttackDown;
            if (pdata.swordspeed > 1)
            {
                animator.speed = 1 + (0.1f *pdata.swordspeed);
            }
            else
            {
                animator.speed = 1;
            }
        }
    }

    void CheckUp(float yVel)
    {
        if(yVel > 0)
        {
            facingUp = true;
        }
        else if (yVel < 0)
        {
            facingUp = false;
        }
    }

    void CheckForIdle()
    {
        if (!controller.isAttacking)
        {
            animator.runtimeAnimatorController = Idle;
        }
    }

    void FlipX(float xVel)
    {
        if(xVel > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (xVel < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

}
