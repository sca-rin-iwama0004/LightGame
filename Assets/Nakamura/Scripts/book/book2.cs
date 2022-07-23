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

        if (b == 1)
        {
            toggle.isOn = true;
	        toggle.interactable = false;
        }

    }

    public void OnToggleChanged()
    {
	if (b == 0)
       	{
		if (coinstone.allcoin < 500)
        	{
            		toggle.isOn = false;
        	}

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

