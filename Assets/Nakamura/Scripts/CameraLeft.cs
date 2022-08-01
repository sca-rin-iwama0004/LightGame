using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeft : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite eye;//目が閉じてる敵画像
    [SerializeField] private Sprite enemy3;//目が開いてる敵画像
    [SerializeField] private GameObject enemy4;//出現させる敵
    private float time = 0f;
    private int sleep = 3;//画像切り替えの間隔
    private int en = 0;//生成された敵の数
    private float arealr = 0.0f;//カメラの範囲(上下)
    private float areaud = 0.0f;//カメラの範囲(左右)
    Rigidbody2D rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //秒数/10の余りがsleepより小さいなら目が開く
        if(time%10 <=sleep)
        {
            MainSpriteRenderer.sprite = enemy3;

        }
        //それ以外なら閉じる
        else
        {
            MainSpriteRenderer.sprite = eye;
        }

        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //プレイヤーのx座標がー１以上26以下かつy座標が－15以上15以下なら
        if (arealr < 26.0f && arealr > -1.0f)
        {
            if (areaud < 15.0f && areaud > -15.0f)
            {
                float x = this.transform.position.x+3;
                float y = this.transform.position.y;
                //目が開いてるかつ敵が生成されていないなら敵を生成し、enに+1する
                if (MainSpriteRenderer.sprite == enemy3 && en < 1)
                {
                    GetComponent<AudioSource>().Play();
                    Instantiate(enemy4);
                    enemy4.transform.position = new Vector2(x, y);
                    en++;
                }

                //目が閉じたなら生成された敵の数を0に戻す
                if (MainSpriteRenderer.sprite == eye)
                {
                    en = 0;
                }
            }

        }
    }
}
