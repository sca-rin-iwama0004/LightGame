
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public GameObject Panel;
    public Text suuji;
    [SerializeField] protected Button checkButton;


    //êîéöÇÃÉ{É^ÉìÇâüÇµÇΩÇÁ
    public virtual void Push_Button(int number)
    {
        this.checkButton.GetComponent<CheckButton>().Push_Button(number);

        switch (number)
        {
            case 0:
                suuji.text += "0";
                break;
            case 1:
                suuji.text += "1";
                break;
            case 2:
                suuji.text += "2";
                break;
            case 3:
                suuji.text += "3";
                break;
            case 4:
                suuji.text += "4";
                break;
            case 5:
                suuji.text += "5";
                break;
            case 6:
                suuji.text += "6";
                break;
            case 7:
                suuji.text += "7";
                break;
            case 8:
                suuji.text += "8";
                break;
            case 9:
                suuji.text += "9";
                break;
            default:
                break;
        }

    }
}
    