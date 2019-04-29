using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorInfo : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Floor " + GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel.ToString();
    }
}
