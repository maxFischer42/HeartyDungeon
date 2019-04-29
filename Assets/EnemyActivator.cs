using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{

    float dis = 5;
    public GameObject effect;
    public Behaviour[] behaviours;
    public GameObject UI;
    public bool isBoss;
    public GameObject[] bossObjects;

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = GameObject.Find("Player").transform.position - transform.position;
        
        if (distance.magnitude < dis)
        {
            for(int i = 0; i < behaviours.Length; i++)
            {
                behaviours[i].enabled = true;
            }
            if(isBoss)
            {
                for (int i = 0; i < bossObjects.Length; i++)
                {
                    bossObjects[i].SetActive(true);
                }
                Camera.main.gameObject.GetComponent<MusicPlayer>().ChangeSong(1);
            }
            UI.SetActive(true);
            GameObject eff = (GameObject)Instantiate(effect, transform);
            Destroy(eff, 4f);
            enabled = false;
        }
    }
}
