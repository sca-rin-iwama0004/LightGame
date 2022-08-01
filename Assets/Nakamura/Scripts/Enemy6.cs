using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy6 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    float rotation_speed =0;//回転スピード
    [SerializeField] private GameObject enemy6shotr;//右への攻撃
    [SerializeField] private GameObject enemy6shotl;//左への攻撃
    [SerializeField] private GameObject enemy6shotrh;//右(上)の生成位置
    [SerializeField] private GameObject enemy6shotlh;//左(下)の生成位置
    [SerializeField] private GameObject enemy6shotrhd;//右(下)の生成位置
    [SerializeField] private GameObject enemy6shotlhu;//左(上)の生成位置
    [SerializeField] private GameObject Coin;//コイン
    [SerializeField] private GameObject Food;//食べ物
    [SerializeField] private GameObject Gold;//資源
    [SerializeField] private GameObject Shot;//攻撃(追跡)

    private float span = 0.5f;//enemy6shotr(上)が生成させる間隔
    private float span2 = 1.0f;//enemy6shotl(下)が生成させる間隔
    private float span3 = 1.5f;//enemy6shotr(下)が生成させる間隔
    private float span4 = 2.0f;//enemy6shotl(上)が生成させる間隔
    private float span5 = 3.0f;//shotが生成させる間隔
    private float time = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float time4 = 0f;
    private float time5 = 0f;
    private float hp = 700;//最大HP
    private float nowhp;//現在のHP
    private float stoptime = 0f;
    private float stop = 9.0f;//回転する時間の間隔
    private float arealr = 0.0f;//攻撃範囲(左右)
    private float areaud = 0.0f;//攻撃範囲(上下)
    [SerializeField] private Slider hpSlider;//HPバー
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;
        hpSlider.value = 1;//HPバーを満タンにする
        nowhp = hp;//現在のHPをボスのHPとする
    }

    // Update is called once per frame
    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //プレイヤーが範囲内に入ったら時間を計測
        if (arealr < 60.0f && arealr > -60.0f)
        {
            if (areaud < 60.0f && areaud > -60.0f)
            {
                stoptime += Time.deltaTime;
                time5 += Time.deltaTime;
                //stoptime/10のあまりがstop以下になったら回転する
                if (stoptime % 10 <= stop)
                {
                    this.rotation_speed = 0.5f;
                    transform.Rotate(0, 0, this.rotation_speed);
                    time += Time.deltaTime;
                    time2 += Time.deltaTime;
                    time3 += Time.deltaTime;
                    time4 += Time.deltaTime;
                    //span秒経過したらenemy6shotrを生成しenemy6shotrhに生成する
                    if (time > span)
                    {
                        Instantiate(enemy6shotr);
                        enemy6shotr.transform.position = enemy6shotrh.transform.position;
                        time = 0f;

                    }
                    //span2秒経過したらenemy6shotlを生成しenemy6shotlhに生成する
                    else if (time2 > span2)
                    {
                        Instantiate(enemy6shotl);
                        enemy6shotl.transform.position = enemy6shotlh.transform.position;
                        time2 = 0f;
                    }
                    //span3秒経過したらenemy6shotrを生成しenemy6shotrhdに生成する
                    else if (time3 > span3)
                    {
                        Instantiate(enemy6shotr);
                        enemy6shotr.transform.position = enemy6shotrhd.transform.position;
                        time3 = 0f;

                    }
                    //span4秒経過したらenemy6shotlを生成しenemy6shotlhuに生成する
                    else if (time4 > span4)
                    {
                        Instantiate(enemy6shotl);
                        enemy6shotl.transform.position = enemy6shotlhu.transform.position;
                        time4 = 0f;
                    }
                }
                //span5秒経過したらshotを生成
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
                while (g < 1)
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
