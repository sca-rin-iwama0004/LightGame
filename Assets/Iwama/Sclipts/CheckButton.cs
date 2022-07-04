using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : text
{
     private string inputString;

    [SerializeField] private TrainScript_a trainA;
    [SerializeField] private TrainScript_b trainB;
    [SerializeField] private TrainScript_c trainC;
    [SerializeField] private GameObject KeyDoor;
    [SerializeField] private GameObject newPanel;
    [SerializeField] private GameObject Enemy;


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
        A.GetNumberA();//マップに何の数字がでてるか

        TrainScript_b B = trainB.GetComponent<TrainScript_b>();
        B.GetNumberB();

        TrainScript_c C = trainC.GetComponent<TrainScript_c>();
        C.GetNumberC();

        int a = A.GetNumberA();
        int b = B.GetNumberB();
        int c = C.GetNumberC();

        int s = int.Parse(inputString);
        Debug.Log("保存されている数値" + s);

       int j = a * 100 + b * 10 + c;


        

        if (s == j) 
       {
           Debug.Log("正解");
           Destroy(KeyDoor);
           newPanel.SetActive(false);

        }
        else{
            Instantiate(Enemy, new Vector3(-47, 64, 0), Quaternion.identity);
            Debug.Log("不正解");

       }
       
        
    }
}
