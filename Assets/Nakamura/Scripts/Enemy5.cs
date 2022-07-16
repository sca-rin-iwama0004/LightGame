using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy5 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    private float hp =500;
    private float nowhp;
    Rigidbody2D rb;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Food;
    [SerializeField] private GameObject Gold;
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 500;
    }

    void Update()
    {
       
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        int coin = 0;
        int c = 0;
        int food = 0;
        int gold = 0;
        int g = 0;
        if (other.gameObject.tag == "Bullet")
        {
            hp -= script.Power;
            hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Gun")
        {
            hp -= (script.Power / 2.0f);
            hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Explosion")
        {
            hp -= 50;
            hpSlider.value = hp;
        }


        if (hp <= 0)
        {
            coin = Random.Range(0, 2);
            food = Random.Range(0, 2);
            gold = Random.Range(0, 2);
            if (coin == 1)
            {
                while (c < 10)
                {
                    Instantiate(Coin);
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Coin.transform.position = new Vector2(x, this.transform.position.y);
                    c++;
                }

            }

            if (food == 1)
            {
                float x = Random.Range(this.transform.position.x + 1, this.transform.position.x - 1);
                Instantiate(Food);
                Food.transform.position = new Vector2(x, this.transform.position.y);
            }

            if(gold == 1)
            {
                while(g < 1)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Gold);
                    Gold.transform.position = new Vector2(x, this.transform.position.y);
                    g++;
                }
                  
            }
            this.gameObject.SetActive(false);
        }
    }
}