using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy5 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    private float hp =700;//最大HP
    private float nowhp;//現在のHP
    [SerializeField] private GameObject Coin;//コイン
    [SerializeField] private GameObject Food;//食べ物
    [SerializeField] private GameObject Gold;//資源
    public Slider hpSlider;//HPバー
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;//HPバーを満タンにする
        nowhp = hp;//現在のHPを最大のHPとする
    }

    void Update()
    {
       
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        int coin = 0;//コインを出すか出さないかの判定
        int food = 0;//食べ物を出すか出さないかの判定
        int gold = 0;//資源を出すか出さないかの判定
        int c = 0;//出現したコインの枚数
        int g = 0;//出現した資源の枚数

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
            gold = Random.Range(0, 2);
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

            //goldの値が1ならgが10以上になるまで資源を生成する
            if (gold == 1)
            {
                while(g < 1)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Gold, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    g++;
                }
                  
            }
            this.gameObject.SetActive(false);//このオブジェクトを消す
        }
    }
}