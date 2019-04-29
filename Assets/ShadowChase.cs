using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChase : MonoBehaviour
{
    public float speed;
    public float distance;
    public Rigidbody2D rig;
    public GameObject hitbox;
    public float timeToAttack;
    public float timeToFinish;

    public RuntimeAnimatorController move;
    public RuntimeAnimatorController startup;
    public RuntimeAnimatorController attack;
    public Animator anim;

    public bool isAttacking;

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.5f);
        GameData data = GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData;
        speed = speed + (0.5f * data.currentLevel);
        distance = distance - (0.5f * data.currentLevel);

    }

    // Update is called once per frame
    void Update()
    {

        if (isAttacking)
            return;
        Vector3 player = GameObject.Find("Player").transform.position;
        Vector3 direction = player - transform.position;
        if(direction.magnitude < distance)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
        else
        {
            
            direction.Normalize();
            rig.velocity = direction * speed;
        }

    }

    public IEnumerator Attack()
    {
         anim.runtimeAnimatorController = attack;
         yield return new WaitForSeconds(timeToAttack);
        //spawn hitbox;
        GameObject hb = (GameObject)Instantiate(hitbox, transform);
        hb.transform.parent = null;
        Destroy(hb, 0.1f);
        yield return new WaitForSeconds(timeToFinish);
        isAttacking = false;
        anim.runtimeAnimatorController = move;
        distance -= 0.05f;
    }
}
