using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book1 : MonoBehaviour
{
    
    [SerializeField] private Toggle toggle;
    public static int a =0;
    public static bool shopDefense;

    void Start()
    {
        //すでに買っているなら、クリックができないようにし、チェックマークを付ける
        if (a == 1)
        {

	        toggle.interactable = false;
            toggle.isOn = true;
        }
    }

    void Update()
    {
       
    }
    public void OnToggleChanged()
    {
        //購入していなければ
        if (a == 0)
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
                    toggle.interactable = false;
	    		    a = 1;
                    shopDefense = true;
            }

        } 
         
        
       
    }

}
