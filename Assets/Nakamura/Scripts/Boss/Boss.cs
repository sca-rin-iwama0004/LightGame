using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    SpriteRenderer MainSpriteRendererD;
    SpriteRenderer MainSpriteRendererU;
    SpriteRenderer MainSpriteRendererR;
    SpriteRenderer MainSpriteRendererL;
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite atk;//ボスの攻撃の画像
    [SerializeField] private Sprite o2up; //ボスの攻撃(酸素)の画像
    [SerializeField] private Sprite explosion;//爆発時の画像
    [SerializeField] private GameObject enemyshotR;//右への攻撃
    [SerializeField] private GameObject enemyshotL;//左への攻撃
    [SerializeField] private GameObject enemyshotU;//上への攻撃
    [SerializeField] private GameObject enemyshotD;//下への攻撃
    [SerializeField] private GameObject enemy6r;//right方向(下)の攻撃
    [SerializeField] private GameObject enemy6l;//left方向(下)の攻撃
    [SerializeField] private GameObject enemy6rd;//enemy6rの生成位置
    [SerializeField] private GameObject enemy6ld;//enemy6lの生成位置
    [SerializeField] private GameObject enemy6R;//right方向(上)の攻撃
    [SerializeField] private GameObject enemy6L;//left方向(上)の攻撃
    [SerializeField] private GameObject enemy6ru;//enemy6Rの生成位置
    [SerializeField] private GameObject enemy6lu;//enemy6Lの生成位置
    [SerializeField] private Slider hpSlider;//HPバー
    [SerializeField] private GameObject Coin;//コイン
    private float span = 1.0f;//enemy6r,enemy6Lが生成される間隔
    private float span2 = 1.5f;//enemy6l,enemy6Rが生成される間隔
    private float span3 = 3.0f;//enemyshotR～enemyshotDが生成される間隔
    private float time1 = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private int o2d = 0;
    private int o2u = 0;
    private int o2r = 0;
    private int o2l = 0;
    private float hp = 1500;//ボスの最大HP
    private float nowhp;//ボスの現在のHP
    Rigidbody2D rb;
    private float arealr = 0.0f;//攻撃範囲(左右)
    private float areaud = 0.0f;//攻撃範囲(上下)
    GameObject Slider;
    private int counter = 0;
    private float move = 0.05f;//ボスの動くスピード
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        MainSpriteRendererD = enemyshotD.GetComponent<SpriteRenderer>();
        MainSpriteRendererR = enemyshotR.GetComponent<SpriteRenderer>();
        MainSpriteRendererL = enemyshotL.GetComponent<SpriteRenderer>();
        MainSpriteRendererU = enemyshotU.GetComponent<SpriteRenderer>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        Slider = GameObject.Find("Bosshp");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;//HPバーを満タンにする
        nowhp = hp;//現在のHPをボスのHPとする
        Slider.SetActive(true);//HPバーを表示する
    }

    void Update()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        Vector3 p = new Vector3(move,0,0);
        transform.Translate(p);
        counter++;
        //couterが500になったら反対方向に進む
        if (counter == 500)
        {
            move *= -1;
        }
        //couterが1500になったらcounterを0にし、進む方向が戻る
        else if (counter == 1500)
        {
            counter = 0;
        }
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        recovery();

        //現在のHPが0になったら動きを止め、画像を爆発に変え、HPバーを消し、tagをexplosionに変更し、2秒後にEndメソッドに移動する
        if (nowhp <= 0)
        {
            this.transform.position = new Vector2(x, y);
            MainSpriteRenderer.sprite = explosion;
            Slider.SetActive(false);
            this.tag = "explosion";
            Invoke("End", 2.0f);
        }
        //プレイヤーが範囲に入ったら位置を求め、時間を計測
        else if (arealr < 60.0f && arealr > -60.0f)
        {
            if (areaud < 60.0f && areaud > -60.0f)
            {
                time1 += Time.deltaTime;
                time2 += Time.deltaTime;
                time3 += Time.deltaTime;
                //span3秒経過したらenemyshotR～enemyshotDを生成
                if (time3 > span3 && this.tag != "explosion")
                {
                    Instantiate(enemyshotR);
                    Instantiate(enemyshotL);
                    Instantiate(enemyshotU);
                    Instantiate(enemyshotD);
                    enemyshotR.transform.position = new Vector2(x, y);
                    enemyshotL.transform.position = new Vector2(x, y);
                    enemyshotU.transform.position = new Vector2(x, y);
                    enemyshotD.transform.position = new Vector2(x, y);
                    time3 = 0f;
                }
                //span秒経過したらenemy6r,enemy6Lの生成
                if (time1 > span && this.tag != "explosion")
                {
                    Instantiate(enemy6r);
                    Instantiate(enemy6L);
                    enemy6r.transform.position = enemy6rd.transform.position;
                    enemy6L.transform.position = enemy6lu.transform.position;
                    time1 = 0f;

                }
                //span2秒経過したらenemy6l,enemy6Rの生成
                if (time2 > span2 && this.tag != "explosion")
                {
                    Instantiate(enemy6l);
                    Instantiate(enemy6R);
                    enemy6l.transform.position = enemy6ld.transform.position;
                    enemy6R.transform.position = enemy6ru.transform.position;
                    time2 = 0f;
                }
            }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
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
    }





    void recovery()
    {
        o2d = Random.Range(1, 11);
        //o2dの値が9以上なら攻撃を酸素にし、tagをO2にする
        if (o2d >= 9)
        {
            MainSpriteRendererD.sprite = o2up;
            enemyshotD.tag = "O2";
        }
        //それ以外なら攻撃をし、tagはBossにする
        else
        {
            MainSpriteRendererD.sprite = atk;
            enemyshotD.tag = "Boss";
        }



        o2u = Random.Range(1, 11);
        //o2uの値が9以上なら攻撃を酸素にし、tagをO2にする
        if (o2u >= 9)
        {
            MainSpriteRendererU.sprite = o2up;
            enemyshotU.tag = "O2";
        }

        //それ以外なら攻撃をし、tagはBossにする
        else
        {
            MainSpriteRendererU.sprite = atk;
            enemyshotU.tag = "Boss";
        }



        o2r = Random.Range(1, 11);
        //o2rの値が9以上なら攻撃を酸素にし、tagをO2にする
        if (o2r >= 9)
        {
            MainSpriteRendererR.sprite = o2up;
            enemyshotR.tag = "O2";
        }

        //それ以外なら攻撃をし、tagはBossにする
        else
        {
            MainSpriteRendererR.sprite = atk;
            enemyshotR.tag = "Boss";
        }



        o2l = Random.Range(1, 11);
        //o2lの値が9以上なら攻撃を酸素にし、tagをO2にする
        if (o2l >= 9)
        {
            MainSpriteRendererL.sprite = o2up;
            enemyshotL.tag = "O2";
        }

        //それ以外なら攻撃をし、tagはBossにする
        else
        {
            MainSpriteRendererL.sprite = atk;
            enemyshotL.tag = "Boss";
        }
    }

    //クリア画面に移動し、ボスを消す
    void End()
    {
        SceneManager.LoadScene("Clear");
        this.gameObject.SetActive(false);
    }
}
