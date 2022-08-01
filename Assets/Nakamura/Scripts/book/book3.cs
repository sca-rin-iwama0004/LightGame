using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book3 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static int c = 0;
    public static bool shopRec;

    void Start()
    {
        //すでに買っているなら、クリックができないようにし、チェックマークを付ける
        if (c == 1)
        {
            toggle.isOn = true;
            toggle.interactable = false;
        }
    }

    public void OnToggleChanged()
    {
        //購入していなければ
        if (c == 0)
        {
            //コインの枚数が1000以下ならチェックマークを付けない
            if (coinstone.allcoin < 1000)
            {
                toggle.isOn = false;
            }

            //枚数が1000以上かつクリックされたら購入
            if (coinstone.allcoin >= 1000 && toggle.isOn == true)
            {
                coinstone.allcoin -= 1000;
                toggle.interactable = false;
                shopRec = true;
                c = 1;
            }


        }



    }
}
