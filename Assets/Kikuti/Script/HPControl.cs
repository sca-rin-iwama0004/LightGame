using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{
    //HP

    private Image image;

    GameObject player;
    PlayerControl script;

    //自動回復
    private float recTime=0f;
    private float recSpan=1.0f;//回復ペース


    private void Start()
    {
        image = this.GetComponent<Image>();

        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

    }

    private void Update()
    {

       image.fillAmount = script.HP / 160;

        if(script.Rec==true)//自動回復アイテム取得時実行
        {

            recTime += Time.deltaTime;

            if (recTime > recSpan)
            {
                if (script.HP<script.HPLimit)
                {
                    script.HP += 0.1f;//0.1回復
                }
                recTime = 0f;
            }
        }
    }
}
