using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHearts : MonoBehaviour
{
    public GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, spawns.Length);
        spawns[r].SetActive(true);
    }

}
