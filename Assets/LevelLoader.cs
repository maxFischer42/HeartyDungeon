using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public string LevelName;
    public Canvas canvas;
    public int id;
    public bool isLoading;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            id = GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel;
            canvas.enabled = true;
        }
    }

    public void Update()
    {
        if (!isLoading)
            return;

        Image fadeout = GameObject.Find("Player").GetComponent<PlayerHealth>().fadeout;


        Color color = fadeout.color;
        color.a += 0.05f;
        fadeout.color = color;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel = id + 1;
            isLoading = true;
            StartCoroutine(delayLoad());
        }
    }

    public IEnumerator delayLoad()
    {
        GameObject player = GameObject.Find("Player");
        Controller controller = player.GetComponent<Controller>();
        controller.GetComponent<PlayerHealth>().enabled = false;
        Kunai kunai = player.GetComponent<Kunai>();
        Camera.main.GetComponent<AudioSource>().enabled = false;
        controller.enabled = false;
        kunai.enabled = false;
        yield return new WaitForSeconds(1f);
        if (GameObject.Find("LevelGenerator").GetComponent<LevelManager>().gameData.currentLevel > GameObject.Find("Player").GetComponent<Controller>().playerData.maxlevels)
        {
            SceneManager.LoadScene("FinalFloor");
        }
        else
        {
            SceneManager.LoadScene(LevelName);
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
