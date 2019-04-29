using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text damage;
    public Text spend;
    public Text kills;
    public PlayerData data;
    public GameObject but;
    public Text bonus;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayAfterTime());
    }


    IEnumerator displayAfterTime()
    {
        yield return new WaitForSeconds(3.5f);
        damage.text = "Total Damage Recieved :     " + data.totaldamage;
        yield return new WaitForSeconds(3.5f);
        spend.text = "Total Life Traded :     " + data.totalspent;
        yield return new WaitForSeconds(3.5f);
        kills.text = "Total Enemies Defeated:     " + data.totalkills;
        yield return new WaitForSeconds(3.5f);
        if(PlayerPrefs.GetInt("Complete") == 0)
        {
            bonus.enabled = true;
            PlayerPrefs.SetInt("Complete", 1);
        }
        but.SetActive(true);

    }
}
