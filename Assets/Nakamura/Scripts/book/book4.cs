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

        
    }

    public void OnToggleChanged()
    {
    if (d == 0)
	{
		if (coinstone.allcoin < 1000)
        	{
            		toggle.isOn = false;
        	}

	 	if (coinstone.allcoin >= 1000)
        	{
            		coinstone.allcoin -= 1000;
            		toggle.interactable = false;
                    shopResu = true;
        	}

	}

        
       
    }
}
