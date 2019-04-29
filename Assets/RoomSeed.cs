using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSeed : MonoBehaviour
{
    public GameObject[] variants;
    public int[] repeats;
    public GameObject exit;

    private void Start()
    {
        exit = GameObject.FindObjectOfType<LevelGenerator>().EXIT;
        StartCoroutine(lateStart());
    }

    IEnumerator lateStart()
    {
        yield return new WaitForSeconds(0.1f);
        if (transform.parent.Find("PlayerObject(Clone)"))
        {
            Debug.Log("Player found, ending script");
        }
        else
        {
            List<GameObject> seeds = new List<GameObject>();
            for (int i = 0; i < variants.Length - 1; i++)
            {
                for (int r = 0; r < repeats[r]; r++)
                {
                    Debug.Log("i = " + i + " , r = " + r);
                    seeds.Add(variants[i]);
                    Random.Range(0, 20);
                    if(Random.Range(0, 20) == 0)
                    {
                        GameObject.FindObjectOfType<LevelGenerator>().placedExit = true;
                        Instantiate(exit, transform);
                    }

                }
            }
            GameObject[] array = seeds.ToArray();
            int b = Random.Range(0, array.Length - 1);
            Instantiate(array[b], transform);
        }
    }

}