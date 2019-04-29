using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSprite : MonoBehaviour
{
    public Sprite spU, spD, spR, spL, spUD, spRL, spUR, spUL, spDR, spDL, spULD, spRUL, spDRU, spLDR, spUDLR;
    public GameObject _up, _down, _right, _left, updown, rightleft, upright, upleft, downright, downleft, upleftdown, rightupleft, downrightup, leftdownright, updownleftright;

    public GameObject player;

    public bool up, down, left, right;

    public int type; // 0: normal, 1: enter

    public Color normalColor, enterColor;

    Color mainColor;
    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        mainColor = normalColor;
        PickSprite();

        PickColor();
    }

    void PickSprite()
    { //picks correct sprite based on the four door boolsg
        GameObject obj;
        if (up)
        {
            if (down)
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spUDLR;
                        obj = updownleftright;
                    }
                    else
                    {
                        rend.sprite = spDRU;
                        obj = downrightup;
                    }
                }
                else if (left)
                {
                    rend.sprite = spULD;
                    obj = upleftdown;
                }
                else
                {
                    rend.sprite = spUD;
                    obj = updown;
                }
            }
            else
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spRUL;
                        obj = rightupleft;
                    }
                    else
                    {
                        rend.sprite = spUR;
                        obj = upright;
                    }
                }
                else if (left)
                {
                    rend.sprite = spUL;
                    obj = upleft;
                }
                else
                {
                    rend.sprite = spU;
                    obj = _up;
                }
            }
            Instantiate(obj, transform);
            return;
        }
        if (down)
        {
            if (right)
            {
                if (left)
                {
                    rend.sprite = spLDR;
                    obj = leftdownright;
                }
                else
                {
                    rend.sprite = spDR;
                    obj = downright;
                }
            }
            else if (left)
            {
                rend.sprite = spDL;
                obj = downleft;
            }
            else
            {
                rend.sprite = spD;
                obj = _down;
            }
            Instantiate(obj, transform);
            return;
        }
        if (right)
        {
            if (left)
            {
                rend.sprite = spRL;
                obj = rightleft;
            }
            else
            {
                rend.sprite = spR;
                obj = _right;
            }
        }
        else
        {
            rend.sprite = spL;
            obj = _left;
        }
        Instantiate(obj, transform);
    }

    void PickColor()
    { //changes color based on what type the room is
        if (type == 0)
        {
            mainColor = normalColor;
        }
        else if (type == 1)
        {
            mainColor = enterColor;
            Instantiate(player, transform);
            player.transform.parent = null;
        }
        rend.color = mainColor;
    }

}
