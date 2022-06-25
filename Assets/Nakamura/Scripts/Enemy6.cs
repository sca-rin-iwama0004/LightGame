using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    float rotation_speed =0;
    [SerializeField] private GameObject enemy6r;
    [SerializeField] private GameObject enemy6l;
    [SerializeField] private GameObject enemy6shotr;
    [SerializeField] private GameObject enemy6shotl;
    [SerializeField] private GameObject Food;
    [SerializeField] private GameObject Gold;
    [SerializeField] private GameObject Shot;
    private float span = 0.5f;
    private float span2 = 1.0f;
    private float span3 = 5.0f;
    private float time = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float hp = 500;
    private float stoptime = 0f;
    private float stop = 9.0f;
    [SerializeField] private GameObject Coin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        time3 += Time.deltaTime;
        if (time3 % 10 > span3)
        {
            Instantiate(Shot);
            Shot.transform.position = this.transform.position;
            time3 = 0f;
        }

        stoptime += Time.deltaTime;
        if(stoptime % 10 <= stop)
        {
            this.rotation_speed = 0.5f;
            transform.Rotate(0, 0, this.rotation_speed);
            time += Time.deltaTime;
            time2 += Time.deltaTime;
            if (time > span)
            {
                Instantiate(enemy6r);
                enemy6r.transform.position = enemy6shotr.transform.position;
                time = 0f;

            }
            else if (time2 > span2)
            {
                Instantiate(enemy6l);
                enemy6l.transform.position = enemy6shotl.transform.position;
                time2 = 0f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int coin = 0;
        int c = 0;
        int food = 0;
        int gold = 0;
        int g = 0;
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
            gold = Random.Range(0, 2);
            Debug.Log(coin);
            Debug.Log(food);
            Debug.Log(gold);
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

            if (gold == 1)
            {
                while (g < 1)
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
