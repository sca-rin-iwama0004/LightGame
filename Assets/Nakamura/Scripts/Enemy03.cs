using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy03 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    [SerializeField] private GameObject Coin;//コイン
    [SerializeField] private GameObject Food;//食べ物
    [SerializeField] private GameObject Silver;//資源
    public Slider hpSlider;//HPバー
    private float Speed = 3;//移動速度
    private float hp = 300;//最大HP
    private float nowhp;//現在のHP
    private float arealr = 0.0f;//攻撃範囲(左右)
    private float areaud = 0.0f;//攻撃範囲(上下)
    private float x;//初期位置（x座標）
    private float y;//初期位置（ｙ座標）
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;//HPバーを満タンにする
        nowhp = hp;//現在のHPを最大のHPとする
        x = this.transform.position.x;
        y = this.transform.position.y;
    }

    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //プレイヤーが範囲に入ったらプレイヤーの方向へ移動する
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
        //Wall,Botton,Doorのどれかに当たったら初期位置へと戻る
        if (other.gameObject.tag == "Wall"|| other.gameObject.tag == "Botton" || other.gameObject.tag == "Door")
        {
            this.transform.position = new Vector2(x, y);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        int coin = 0;//コインを出すか出さないかの判定
        int food = 0;//食べ物を出すか出さないかの判定
        int silver = 0;//資源を出すか出さないかの判定
        int c = 0;//出現したコインの枚数
        int s = 0;//出現した資源の枚数

        //Bulletに当たったなら現在のHPをPowerぶん減らし、HPバーにも反映させる
        if (other.gameObject.tag == "Bullet")
        {
            nowhp -= script.Power;
            hpSlider.value = nowhp / hp;
        }
        //Gunに当たったなら現在のHPをPower/2ぶん減らし、HPバーにも反映させる
        if (other.gameObject.tag == "Gun")
        {
            nowhp -= (script.Power / 2);
            hpSlider.value = nowhp / hp;
        }
        //Explosionに当たったなら現在のHPを50減らし、HPバーにも反映させる
        if (other.gameObject.tag == "Explosion")
        {
            nowhp -= 50;
            hpSlider.value = nowhp / hp;
        }

        //現在のHPが0なら
        if (nowhp <= 0)
        {
            coin = Random.Range(0, 2);
            food = Random.Range(0, 2);
            silver = Random.Range(0, 2);

            //coinの値が1ならｃが10以上になるまでコインを生成する
            if (coin == 1)
            {
                while (c < 10)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Coin, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    c++;
                }
            }

            //foodの値が1なら食べ物を生成する
            if (food == 1)
            {
                Instantiate(Food, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }

            //silverの値が1ならsが10以上になるまで資源を生成する
            if (silver == 1)
            {
                while (s < 1)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Silver, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    s++;
                }

            }
            this.gameObject.SetActive(false);//このオブジェクトを消す
        }
    }
}
