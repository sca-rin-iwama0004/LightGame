using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book4 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static int d = 0;
    public static bool shopResu;

    void Start()
    {
        //すでに買っているなら、クリックができないようにし、チェックマークを付ける
        if (d == 1)
        {
            toggle.isOn = true;
            toggle.interactable = false;
        }
    }

    public void OnToggleChanged()
    {
        //購入していなければ
        if (d == 0)
        {
            //コインの枚数が5000以下ならチェックマークを付けない
            if (coinstone.allcoin < 5000)
            {
                toggle.isOn = false;
            }

            //枚数が5000以上かつクリックされたら購入
            if (coinstone.allcoin >= 5000)
            {
                coinstone.allcoin -= 5000;
                toggle.interactable = false;
                shopResu = true;
                d = 1;
            }

        }



    }
}
