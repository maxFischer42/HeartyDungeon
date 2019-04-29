using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public UIList textboxes;
    public PlayerData playerData;
    public Kunai kunaiScript;
    public Controller controller;
    public SwordData sword;
    public KunaiData kunai;

    // Update is called once per frame
    void Update()
    {
        if (playerData.speed > 3)
            controller.speed = 3 + (0.1f * (playerData.speed - 2));

        textboxes.healthText.text = playerData.health.ToString();
        textboxes.ammoText.text = playerData.ammo.ToString();
        textboxes.speedText.text = playerData.speed.ToString();
        textboxes.defenseText.text = playerData.defense.ToString();
        textboxes.swordSpeedText.text = playerData.swordspeed.ToString();
        textboxes.swordDamageText.text = playerData.sworddamage.ToString();
        textboxes.kunaiSpeedText.text = playerData.kunaispeed.ToString();
        textboxes.kunaiDamageText.text = playerData.kunaidamage.ToString();

        if (playerData.swordspeed > 1)
        {
            controller.attackCooldown = 0.6f - (0.05f * playerData.swordspeed);
        }
        else
        {
            controller.attackCooldown = 0.6f;
        }
        if(playerData.kunaispeed > 1)
        {
            kunaiScript.throwSpeed = 5f + (1.5f * playerData.kunaispeed);
            kunaiScript.cooldown = 1f - (0.05f * playerData.kunaispeed);
        }
        else
        {
            kunaiScript.throwSpeed = 5f;
            kunaiScript.cooldown = 1f;
        }
        sword.damage = playerData.sworddamage;
        kunai.damage = playerData.kunaidamage;
    }
}

[System.Serializable]
public class UIList
{
    public Text healthText;
    public Text ammoText;
    public Text speedText;
    public Text defenseText;
    public Text swordSpeedText;
    public Text swordDamageText;
    public Text kunaiSpeedText;
    public Text kunaiDamageText;
}
