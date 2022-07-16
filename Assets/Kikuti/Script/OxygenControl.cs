using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenControl : MonoBehaviour
{
   
    private Image image;

    GameObject player;
    PlayerControl script;

    private float o2Time = 0f;
    private float o2Span = 0.2f;  //通常酸素減少ペース

    private float span = 1.0f;  //酸素ボンベ回復ペース
    private float currentTime = 0f;
    private float o2Up=0.5f;  //通常酸素減少率

    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();

        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //通常酸素減少
        o2Time += Time.deltaTime;
        if (o2Time > o2Span)
        {
            script.Oxygen -= 0.2f;
            o2Time = 0f;
        }

        image.fillAmount = script.Oxygen / script.OxygenMax;//表示
        
       if(script.PlaceO2 == true)//酸素ボンベエリア
       {
            currentTime += Time.deltaTime;

            if (currentTime > span)
            { 
                    script.Oxygen += script.OxygenMax * 0.3f; 
                    currentTime = 0f;   
            }
        }
        if (script.Oxygen >= script.OxygenMax)
        {
            script.Oxygen = script.OxygenMax;
        }
    }

    public float O2Up
    {
        set { this.o2Up = value; }
        get { return this.o2Up; }
    }
}
