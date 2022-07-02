using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    private float Speed = 3;
    private  float hp =200;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Food;
    [SerializeField] private GameObject Silver;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }
   
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y), Speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int coin = 0;
        int food = 0;
        int silver = 0;
        int c = 0;
        int s = 0;
        if (other.gameObject.tag == "Bullet")
        {
            hp -= script.Power;
        }
       if (other.gameObject.tag == "Gun")
        {
           hp -= (script.Power / 2.0f);
        }
        if (other.gameObject.tag == "Explosion")
        {
            hp -= 50;
        }

        if (hp <= 0)
            {
                coin = Random.Range(0, 2);
                food = Random.Range(0, 2);
                silver = Random.Range(0,2);
                Debug.Log(coin);
                Debug.Log(food);
                if (coin  == 1)
                {
                    while(c < 10)
                    {
                        Instantiate(Coin);
                        float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                        Coin.transform.position = new Vector2(x, this.transform.position.y);
                        c++;
                    }
                   
                }

                if(food == 1)
                {
                    float x = Random.Range(this.transform.position.x + 1, this.transform.position.x - 1);
                    Instantiate(Food);
                    Food.transform.position = new Vector2(x, this.transform.position.y);
                }

                if (silver == 1)
                {
                    while(s < 1)
                    {
                        float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                        Instantiate(Silver);
                        Silver.transform.position = new Vector2(x, this.transform.position.y);
                        s++;
                    }
                   
                }
                this.gameObject.SetActive(false);
            }
    }
}
