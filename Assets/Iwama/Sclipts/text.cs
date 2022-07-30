
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{

    public GameObject Panel;
    public Text suuji_text;
    [SerializeField] protected Button checkButton;


    //É{É^ÉìÇâüÇµÇΩÇÁé¿çs
    public virtual void Push_Button(int number)
    {
        this.checkButton.GetComponent<CheckButton>().Push_Button(number);

        switch (number)
        {

            case 0:
                suuji_text.text += "0";
                break;
            case 1:
                suuji_text.text += "1";
                break;
            case 2:
                suuji_text.text += "2";
                break;
            case 3:
                suuji_text.text += "3";
                break;
            case 4:
                suuji_text.text += "4";
                break;
            case 5:
                suuji_text.text += "5";
                break;
            case 6:
                suuji_text.text += "6";
                break;
            case 7:
                suuji_text.text += "7";
                break;
            case 8:
                suuji_text.text += "8";
                break;
            case 9:
                suuji_text.text += "9";
                break;
            default:
                break;
        }

    }
    
   
}
    