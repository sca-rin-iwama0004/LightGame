using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHole2 : MonoBehaviour
{
    //ジャンプ先に穴があるか判定スクリプト（下）
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

    //ジャンプ先に穴があるか
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hole")
        {
            script.JumpHole2 = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hole")
        {
            script.JumpHole2 = false;
        }
    }
}
