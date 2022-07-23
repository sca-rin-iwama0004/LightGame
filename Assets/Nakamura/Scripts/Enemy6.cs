using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy6 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    float rotation_speed =0;
    [SerializeField] private GameObject enemy6shotr;
    [SerializeField] private GameObject enemy6shotl;
    [SerializeField] private GameObject enemy6shotrh;
    [SerializeField] private GameObject enemy6shotlh;
    [SerializeField] private GameObject enemy6shotrhd;
    [SerializeField] private GameObject enemy6shotlhu;
    [SerializeField] private GameObject Food;
    [SerializeField] private GameObject Gold;
    [SerializeField] private GameObject Shot;

    private float span = 0.5f;
    private float span2 = 1.0f;
    private float span3 = 1.5f;
    private float span4 = 2.0f;
    private float span5 = 3.0f;
    //private float span5 = 5.0f;
    private float time = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float time4 = 0f;
    private float time5 = 0f;
    //private float time5 = 0f;
    private float hp = 700;
    private float nowhp;
    private float stoptime = 0f;
    private float stop = 9.0f;
    [SerializeField] private GameObject Coin;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;
        nowhp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //プレイヤーが範囲内に入ったら生成
        //Debug.Log(arealr);
        if (arealr < 60.0f && arealr > -60.0f)
        {
            if (areaud < 60.0f && areaud > -60.0f)
            {
                stoptime += Time.deltaTime;
                time5 += Time.deltaTime;
                if (stoptime % 10 <= stop)
                {
                    this.rotation_speed = 0.5f;
                    transform.Rotate(0, 0, this.rotation_speed);
                    time += Time.deltaTime;
                    time2 += Time.deltaTime;
                    time3 += Time.deltaTime;
                    time4 += Time.deltaTime;
                    if (time > span)
                    {
                        Instantiate(enemy6shotr);
                        enemy6shotr.transform.position = enemy6shotrh.transform.position;
                        time = 0f;

                    }
                    else if (time2 > span2)
                    {
                        Instantiate(enemy6shotl);
                        enemy6shotl.transform.position = enemy6shotlh.transform.position;
                        time2 = 0f;
                    }

                    else if (time3 > span3)
                    {
                        Instantiate(enemy6shotr);
                        enemy6shotr.transform.position = enemy6shotrhd.transform.position;
                        time3 = 0f;

                    }
                    else if (time4 > span4)
                    {
                        Instantiate(enemy6shotl);
                        enemy6shotl.transform.position = enemy6shotlhu.transform.position;
                        time4 = 0f;
                    }
                }

                if (time5 % 10 > span5)
                {
                    Instantiate(Shot);
                    Shot.transform.position = this.transform.position;
                    time5 = 0f;
                }
            }
        }

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
     
            //coinが1ならコインを生成する
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

            //foodが1なら食べ物を生成する
            if (food == 1)
            {
                float x = Random.Range(this.transform.position.x + 1, this.transform.position.x - 1);
                Instantiate(Food);
                Food.transform.position = new Vector2(x, this.transform.position.y);
            }

            //goldが1なら資源を生成する
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
