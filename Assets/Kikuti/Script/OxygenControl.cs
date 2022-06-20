using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenControl : MonoBehaviour
{
    private float maxO2 = 200;
    private float decreaseO2 = 200;
    private Image image;

    GameObject player;
    PlayerControl script;

    private float span = 1.0f;
    private float currentTime = 0f;
    private float o2Up=1;


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
        image.fillAmount -= (( Time.deltaTime / decreaseO2 )/o2Up);
        
       if(script.MaxO2==true)
       {
            currentTime += Time.deltaTime;

            if (currentTime > span)
            {
                image.fillAmount += (decreaseO2*0.3f);
                currentTime = 0f;
            }
        }
    }

    public float O2Up
    {
        set { this.o2Up = value; }
        get { return this.o2Up; }
    }
}
