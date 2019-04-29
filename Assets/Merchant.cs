using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public Canvas canvas;
    public Sprite kunai, speed, defense, swordS, swordA, kunaiS, kunaiA;
    public Image productImage;
    public Text priceText;
    public int[] prices = { 25, 50, 75, 100, 150, 200, 300, 500, 1000 };
    public PlayerData playerData;
    public enum Product {Kunai, Speed, Defense,  SwordSpeed, SwordAttack, KunaiSpeed, KunaiAttack};
    public Product myProduct;
    public int productID;
    public int price;
    public int allowedPurchases = 1;
    public bool cooldown;
    public RuntimeAnimatorController doneSelling;

    public AudioClip purchase;
    public AudioClip v;
    public AudioSource aud;

    public GameObject vanish;

    // Start is called before the first frame update
    void Start()
    {
        int range = 6;
        productID = Random.Range(0, range);
        PriceCheck();
        allowedPurchases = Random.Range(1, 4);
    }

    void PriceCheck()
    {
        switch (productID)
        {
            case 0:
                myProduct = Product.Kunai;
                productImage.sprite = kunai;
                price = 5;
                break;
            case 1:
                myProduct = Product.Speed;
                productImage.sprite = speed;
                price = Mathf.RoundToInt(25 * (1.5f * playerData.speed));
                break;
            case 2:
                myProduct = Product.Defense;
                productImage.sprite = defense;
                price = Mathf.RoundToInt(25 * (1.5f * playerData.defense));
                break;
            case 3:
                myProduct = Product.SwordSpeed;
                productImage.sprite = swordS;
                price = Mathf.RoundToInt(25 * (1.5f * playerData.swordspeed));
                break;
            case 4:
                myProduct = Product.SwordAttack;
                productImage.sprite = swordA;
                price = Mathf.RoundToInt(25 * (1.5f * playerData.sworddamage));
                break;
            case 5:
                myProduct = Product.KunaiSpeed;
                productImage.sprite = kunaiS;
                price = Mathf.RoundToInt(25 * (1.5f * playerData.kunaispeed));
                break;
            case 6:
                myProduct = Product.KunaiAttack;
                productImage.sprite = kunaiA;
                price = Mathf.RoundToInt(25 * (1.5f * playerData.kunaidamage));
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(allowedPurchases <= 0)
        {
            GetComponent<Animator>().runtimeAnimatorController = doneSelling;
            canvas.enabled = false;
            enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GameObject _vanish = (GameObject)Instantiate(vanish, transform);
            _vanish.AddComponent<AudioSource>();
            _vanish.GetComponent<AudioSource>().PlayOneShot(v);
            _vanish.transform.parent = null;
            Destroy(_vanish, 7f);
        }        
        PriceCheck();
        priceText.text = price.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            canvas.enabled = true;
        }
    }

    public IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.6f);
        cooldown = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(Input.GetKey(KeyCode.E)&&!cooldown)
            {
                StartCoroutine(GameObject.Find("Player").GetComponent<PlayerHealth>().colorChange());
                playerData = GameObject.Find("Player").GetComponent<Controller>().playerData;
                playerData.totalspent += price;
                playerData.health -= price;
                switch (productID)
                {
                    case 0:
                        playerData.ammo++;
                        break;
                    case 1:
                        playerData.speed += 1;
                        playerData.priceCatalog[productID - 1] *= 2;
                        break;
                    case 2:
                        playerData.defense += 1;
                        playerData.priceCatalog[productID - 1] *= 2;
                        break;
                    case 3:
                        playerData.swordspeed += 1;
                        playerData.priceCatalog[productID - 1] *= 2;
                        break;
                    case 4:
                        playerData.sworddamage += 1;
                        playerData.priceCatalog[productID - 1] *= 2;
                        break;
                    case 5:
                        playerData.kunaispeed += 1;
                        playerData.priceCatalog[productID - 1] *= 2;
                        break;
                    case 6:
                        playerData.kunaidamage += 1;
                        playerData.priceCatalog[productID - 1] *= 2;
                        break;
                }
                aud.PlayOneShot(purchase);
                allowedPurchases--;
                StartCoroutine(Cooldown());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canvas.enabled = false;
        }
    }
}
