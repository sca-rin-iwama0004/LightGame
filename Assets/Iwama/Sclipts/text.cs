
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使うため追加

public class text : MonoBehaviour
{
    [SerializeField] private Text suuji_text;//Text型の変数suuji_textを宣言
    [SerializeField] protected Button checkButton;
    [SerializeField] GameObject Panel;

    //ボタンを押したら実行する関数　実行するためにはボタンへ関数登録が必要
    //int型の引数numberを宣言
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
    



    public void PushButtonDialBack()
    {
        Panel.SetActive(false);
        Debug.Log("戻る");
    }
}