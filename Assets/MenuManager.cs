using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject main;
    public GameObject options;
    public GameObject tutorial;
    public GameObject tutorial2;
    public PlayerData data;
    public void Begin()
    {
        data.Reset();
        SceneManager.LoadScene("Procedural");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
            PlayerPrefs.SetInt("Complete", 0);
    }

    public void Options()
    {
        main.SetActive(false);
        tutorial.SetActive(false);
        tutorial2.SetActive(false);
        options.SetActive(true);
    }
    public void Main()
    {
        main.SetActive(true);
        tutorial.SetActive(false);
        tutorial2.SetActive(false);
        options.SetActive(false);
    }

    public void TutorialA()
    {
        main.SetActive(false);
        tutorial.SetActive(true);
        tutorial2.SetActive(false);
        options.SetActive(false);
    }
    public void TutorialB()
    {
        main.SetActive(false);
        tutorial.SetActive(false);
        tutorial2.SetActive(true);
        options.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
