using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InputScript : MonoBehaviour
{
    public float xInput;
    public float yInput;
    public float aInput;
    public float bInput;
    public float startInput;
    public PlayerData playerPrefs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if(playerPrefs.WASD)
        {
           WASDCheck();
        }
        else
        {
           ArrowCheck();
        }
    }


    void WASDCheck()
    {
        //check y input
        if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            yInput = 1;
        }
        else if(!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            yInput = -1;
        }
        else
        {
            yInput = 0;
        }
        //check x input
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            xInput = -1;
        }
        else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            xInput = 1;
        }
        else
        {
            xInput = 0;
        }
        //check A input
        if (Input.GetMouseButton(0))
        {
            aInput = 1;
        }
        else
        {
            aInput = 0;
        }
        //check B input
        if (Input.GetMouseButton(1))
        {
            bInput = 1;
        }
        else
        {
            bInput = 0;
        }
        //check start input
        if (Input.GetKey(KeyCode.Escape))
        {
            startInput = 1;
        }
        else
        {
            startInput = 0;
        }
    }


    void ArrowCheck()
    {
        //check y input
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            yInput = 1;
        }
        else if (!Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            yInput = -1;
        }
        else
        {
            yInput = 0;
        }
        //check x input
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            xInput = -1;
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            xInput = 1;
        }
        else
        {
            xInput = 0;
        }
        //check A input
        if (Input.GetKey(KeyCode.Z))
        {
            aInput = 1;
        }
        else
        {
            aInput = 0;
        }
        //check B input
        if (Input.GetKey(KeyCode.X))
        {
            bInput = 1;
        }
        else
        {
            bInput = 0;
        }
        //check start input
        if (Input.GetKey(KeyCode.Return))
        {
            startInput = 1;
        }
        else
        {
            startInput = 0;
        }
    }



}
