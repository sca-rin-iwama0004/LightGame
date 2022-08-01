using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book2 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static bool shopRange;
    public static int b = 0;

    void Start()
    {
        //すでに買っているなら、クリックができないようにし、チェックマークを付ける
        if (b == 1)
        {
            toggle.isOn = true;
	        toggle.interactable = false;
        }

    }

    public void OnToggleChanged()
    {
        //購入していなければ
        if (b == 0)
       	{
            //コインの枚数が500以下ならチェックマークを付けない
            if (coinstone.allcoin < 500)
        	{
            		toggle.isOn = false;
        	}

            //枚数が５００以上かつクリックされたら購入
            if (coinstone.allcoin >= 500 && toggle.isOn == true)
        	{
            		coinstone.allcoin -= 500;
                    shopRange = true;
                    toggle.interactable = false;
	    		    b = 1;
        	}
	    }
        


       
    }
}

