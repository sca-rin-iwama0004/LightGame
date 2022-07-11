using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Shot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshotR;//攻撃(右)
    [SerializeField] private GameObject enemyshotL;//攻撃(左)
    [SerializeField] private GameObject enemyshotU;//攻撃(上)
    [SerializeField] private GameObject enemyshotD;//攻撃(下)
    [SerializeField] private GameObject Shot;//攻撃(追跡)
    GameObject player;
    GameObject enemy4;
    private float span = 2.0f;
    private float time = 0f;
    private float time2 = 0f;
    bool InArea = false;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが範囲内に入ったら生成
        if (InArea == true)
        {
            float x = enemy4.transform.position.x;
            float y = enemy4.transform.position.y;
            time += Time.deltaTime;
            time2 += Time.deltaTime;
            if (time > span)
            {
                Instantiate(enemyshotR);
                Instantiate(enemyshotL);
                Instantiate(enemyshotU);
                Instantiate(enemyshotD);
                enemyshotR.transform.position = new Vector2(x, y);
                enemyshotL.transform.position = new Vector2(x, y);
                enemyshotU.transform.position = new Vector2(x, y);
                enemyshotD.transform.position = new Vector2(x, y);
                time = 0f;
            }
            if (time2 % 10 > span)
            {   
                Instantiate(Shot);
                Shot.transform.position = this.transform.position;
                time2 = 0f;
            }

        }

        arealr = player.transform.position.x - this.transform.position.x;
      
        areaud = player.transform.position.y - this.transform.position.y;
        //プレイヤーが範囲外に出たらfalse
        if (arealr >= 50.0f || arealr <= -50.0f || areaud >= 50.0f || areaud <= -50.0f)
        {
            InArea = false;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーが入ったらtrue
        if (other.gameObject.tag == "Player")
        {
            InArea = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //プレイヤーが入ったらtrue
        if (other.gameObject.tag == "Player")
        {
            InArea = true;
        }
    }

}