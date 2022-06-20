using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{

    private Image image;

    GameObject player;
    PlayerControl script;

    //自動回復
    private float recTime=0f;
    private float recSpan=20.0f;//回復スピード

    private void Start()
    {
        image = this.GetComponent<Image>();

        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

    }

    private void Update()
    {

       image.fillAmount = script.HP / 500.0f;

        if(script.Rec==true)
        {

            recTime += Time.deltaTime;

            if (recTime > recSpan)
            {
                if (script.HP<script.HPLimit)
                {
                    script.HP += 1.0f;
                }
                recTime = 0f;
            }
        }
    }
}
