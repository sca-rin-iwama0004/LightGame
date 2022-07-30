using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy03 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    private float Speed = 3;
    private  float hp =300;
    private float nowhp;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Food;
    [SerializeField] private GameObject Silver;
    public Slider hpSlider;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    private float x;
    private float y;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;
        nowhp = hp;
        x = this.transform.position.x;
        y = this.transform.position.y;
    }

    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //Debug.Log(arealr);
        if (arealr < 35.0f && arealr > -35.0f)
        {
            if (areaud < 35.0f && areaud > -35.0f)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y), Speed * Time.deltaTime);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall"|| other.gameObject.tag == "Botton")
        {
            this.transform.position = new Vector2(x, y);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        int coin = 0;
        int food = 0;
        int silver = 0;
        int c = 0;
        int s = 0;
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
                silver = Random.Range(0,2);
                //Debug.Log(coin);
                //Debug.Log(food);
                if (coin  == 1)
                {
                    while(c < 10)
                    {
                        float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                        Instantiate(Coin, new Vector2(x, this.transform.position.y), Quaternion.identity);
                        c++;
                    }
                   
                }

                if(food == 1)
                {
                    Instantiate(Food, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                }

                if (silver == 1)
                {
                    while(s < 1)
                    {
                        float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                        Instantiate(Silver, new Vector2(x, this.transform.position.y), Quaternion.identity);
                        s++;
                    }
                   
                }
                this.gameObject.SetActive(false);
            }
    }
}
