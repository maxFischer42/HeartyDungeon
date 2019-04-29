using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject myObject;
    private GameObject memoryObject;
    public float respawnTime = 7f;
    public bool respawning = false;

    // Start is called before the first frame update
    void Start()
    {
        memoryObject = myObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0 && !respawning)
        {
            StartCoroutine(SpawnDelay());
        }

    }
    IEnumerator SpawnDelay()
    {
        respawning = true;
        yield return new WaitForSeconds(respawnTime);
        myObject = (GameObject)Instantiate(memoryObject, transform);
        respawning = false;
    }
}
