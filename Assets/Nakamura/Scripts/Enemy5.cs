using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy5 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    private float hp =700;
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
        hpSlider.value = 1;
        nowhp = hp;
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
            nowhp -= script.Power;
            hpSlider.value = nowhp / hp;
        }
        if (other.gameObject.tag == "Gun")
        {
            nowhp -= (script.Power / 2.0f);
            hpSlider.value = nowhp / hp;
        }
        if (other.gameObject.tag == "Explosion")
        {
            nowhp -= 50;
            hpSlider.value = nowhp / hp;
        }


        if (nowhp <= 0)
        {
            coin = Random.Range(0, 2);
            food = Random.Range(0, 2);
            gold = Random.Range(0, 2);
            if (coin == 1)
            {
                while (c < 10)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Coin, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    c++;
                }

            }

            if (food == 1)
            {
                Instantiate(Food, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }

            if (gold == 1)
            {
                while(g < 1)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Gold, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    g++;
                }
                  
            }
            this.gameObject.SetActive(false);
        }
    }
}