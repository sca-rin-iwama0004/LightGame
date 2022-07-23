using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BomGetControl : MonoBehaviour
{
    //効果音
    public GameObject gunSound;

    GameObject player;
    PlayerControl script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーに取得され消える
        if (other.gameObject.tag == "Player")
        {
            script.Ui2 = "Cキーで爆弾を置く";
            script.UiDecision2 = true;

            Instantiate(gunSound, this.transform.position, this.transform.rotation);//効果音
            Destroy(gameObject);
        }

    }


}
