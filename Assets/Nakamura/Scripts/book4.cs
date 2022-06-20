using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book4 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static int d = 0;

    void Start()
    {

        if (d == 1)
        {
            toggle.isOn = true;
            toggle.interactable = false;
        }
        
    }

    public void OnToggleChanged()
    {
        if (d == 0)
	{
		if (coinstone.allcoin < 500)
        	{
            		toggle.isOn = false;
        	}

	 	if (coinstone.allcoin >= 500 && toggle.isOn == true)
        	{
            		coinstone.allcoin -= 500;
            		toggle.interactable = false;
	    		d = 1;
        	}

	}

        
       
    }
}
