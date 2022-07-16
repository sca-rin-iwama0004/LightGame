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
    private float o2Span = 0.2f;  //’Êí_‘fŒ¸­ƒy[ƒX

    private float span = 1.0f;  //_‘fƒ{ƒ“ƒx‰ñ•œƒy[ƒX
    private float currentTime = 0f;
    private float o2Up=0.5f;  //’Êí_‘fŒ¸­—¦

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
        //’Êí_‘fŒ¸­
        o2Time += Time.deltaTime;
        if (o2Time > o2Span)
        {
            script.Oxygen -= 0.2f;
            o2Time = 0f;
        }

        image.fillAmount = script.Oxygen / script.OxygenMax;//•\¦
        
       if(script.PlaceO2 == true)//_‘fƒ{ƒ“ƒxƒGƒŠƒA
       {
            currentTime += Time.deltaTime;

            if (currentTime > span)
            {
                 script.Oxygen +=   script.OxygenMax*0.3f; //span‚²‚Æ‚É30“‰ñ•œ
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
