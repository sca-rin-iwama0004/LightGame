using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRange3Control : MonoBehaviour
{
    //ジャンプ先に床があるか判定スクリプト（左）
    GameObject player;
    PlayerControl script;

    BoxCollider2D boxCol;
    private float posX, posY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

        boxCol = GetComponent<BoxCollider2D>();
        posX = boxCol.size.x;
        posY = boxCol.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプUPのアイテム拾った後のColliderの位置
        if (script.JumpPower == 2)
        {
            boxCol.offset = new Vector3(-3.5f,0, script.JumpPower);
            boxCol.size = new Vector3(script.JumpPower, posY, script.JumpPower);
        }

    }

    //ジャンプ先に床があるか
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            script.JumpDecision3 = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            script.JumpDecision3 = false;
        }
    }
}
