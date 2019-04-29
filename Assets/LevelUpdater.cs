using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpdater : MonoBehaviour
{
    private void Start()
    {
        data.maxlevels = 4;
        field.text = "4";
        if (PlayerPrefs.GetInt("Complete") == 0)
        {
            gameObject.SetActive(false);
        }

    }

    public PlayerData data;
    public InputField field;

    public void UpdateData()
    {
        string str = field.text;
        int i = int.Parse(str);
        if(i <= 0)
        {
            i = 1;
        }
        field.text = i.ToString();
        data.maxlevels = i;
    }
}
