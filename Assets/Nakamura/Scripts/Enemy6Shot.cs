using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Shot : MonoBehaviour
{
    private GameObject enemy6l;
    private GameObject enemy5;
    private float speed = 0.0009f;//攻撃スピード
    float right;
    float up;
    // Start is called before the first frame update
    void Start()
    {
        enemy6l = GameObject.Find("Enemy6ShotLh");
        enemy5 = GameObject.Find("Enemy5");
        //生成された位置のx座標がenemy5のx座標より大きいなら+方向に飛ばす
        if (this.transform.position.x >= enemy5.transform.position.x)
        {
            right = (this.transform.position.x * 2) * speed;
        }
        //それ以外なら-方向に飛ばす
        else
        {
            right = (this.transform.position.x * -2) * speed;
        }

        //生成された位置のｙ座標がenemy5のx座標より大きいなら‐方向に飛ばす
        if (this.transform.position.y >= enemy5.transform.position.y)
        {
            up= (this.transform.position.y * -2) * speed;
            
        }
        //それ以外なら+方向に飛ばす
        else
        {
            up = (this.transform.position.y * 2) * speed;
        }


    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-right, -up, 0.0f);
        float x = enemy6l.transform.position.x;//生成された場所のx座標を取得
        float y = enemy6l.transform.position.y;//生成された場所のy座標を取得
        //オブジェクトの位置が生成された場所のx座標より40以上または40以下、ｙ座標より40以上または40以下ならfalseにする
        if (this.transform.position.x >= x + 40.0f || this.transform.position.x <= x - 40.0f || this.transform.position.y >= y + 40.0f || this.transform.position.y <= y - 40.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet、Player、Wall、Partner、Doorのどれかに当たったならfalseにする
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Partner" || other.gameObject.tag == "Door")
        {
            this.gameObject.SetActive(false);
        }
    }
}
