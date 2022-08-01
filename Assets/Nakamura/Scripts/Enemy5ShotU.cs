using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5ShotU : MonoBehaviour
{
    private float speed = 0.1f;//攻撃のスピード
    GameObject enemy4;
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");
    }

    // Update is called once per frame
    void Update()
    {
        float y = enemy4.transform.position.y;//enemy4のy座標を取得する
        transform.position += new Vector3(0.0f,speed, 0.0f);
        //現在のy座標がenemy4のy座標より45以上離れていたらfalseにする
        if (this.transform.position.y >= y + 45.0f)
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
