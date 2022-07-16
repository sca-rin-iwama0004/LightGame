using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : text
{
    public string inputString;

    [SerializeField] private TrainScript_a trainA;
    [SerializeField] private TrainScript_b trainB;
    [SerializeField] private TrainScript_c trainC;
    [SerializeField] private GameObject KeyDoor;
    [SerializeField] private GameObject Enemy;

    AudioSource audioSource;
    [SerializeField] private AudioClip no;
    [SerializeField] private AudioClip yes;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    public string InputString {
        set { this.inputString = value; }
        get { return this.inputString; }
    }

    public override void Push_Button(int number)
    {
        this.inputString += number;
        Debug.Log(inputString);
        //base.Push_Button(number);

    }

    

    public void PushButtonCheck()
    {
        TrainScript_a A = trainA.GetComponent<TrainScript_a>();
        A.GetNumberA();

        TrainScript_b B = trainB.GetComponent<TrainScript_b>();
        B.GetNumberB();

        TrainScript_c C = trainC.GetComponent<TrainScript_c>();
        C.GetNumberC();

        int a = A.GetNumberA();
        int b = B.GetNumberB();
        int c = C.GetNumberC();

        int s = int.Parse(inputString);
        Debug.Log("ï€ë∂Ç≥ÇÍÇƒÇ¢ÇÈêîíl" + s);

       int j = a * 100 + b * 10 + c;


        

        if (s == j) 
       {
           Debug.Log("ê≥â");
           Destroy(KeyDoor);
            audioSource.PlayOneShot(yes);
            Panel.SetActive(false);

        }
        else{
            Instantiate(Enemy, new Vector3(-47, 64, 0), Quaternion.identity);
           // GetComponent<AudioSource>().Play();
            audioSource.PlayOneShot(no);
            inputString = "";
            Debug.Log("ïsê≥â");

       }
    }

/*
    public void PushButtonDialBack()
    {
        inputString = "";//backÇÃÇçÌèúÇµÇƒÇµÇ‹Ç¡ÇƒÇ¢ÇÈ
        suuji_text.text = "";
        Panel.SetActive(false);

        Debug.Log("ñﬂÇÈ");
    }
*/
  
}
