using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string LevelName;
    public Canvas canvas;
    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            id = GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel;
            canvas.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel = id + 1;
            if (GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel > GameObject.Find("Player").GetComponent<Controller>().playerData.maxlevels)
            {
                SceneManager.LoadScene("FinalFloor");
            }
            else
            {
                SceneManager.LoadScene(LevelName);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.enabled = false;
        }
    }
}
