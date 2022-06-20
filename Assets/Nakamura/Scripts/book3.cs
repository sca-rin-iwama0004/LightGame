using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book3 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static int c = 0;

    void Start()
    {

        if (c == 1)
        {
            toggle.isOn = true;
            toggle.interactable = false;
        }
        
    }

    public void OnToggleChanged()
    {
       
	if (c == 0)
	{
		if (coinstone.allcoin < 400)
        	{
            		toggle.isOn = false;
        	}

	  	if (coinstone.allcoin >= 400 && toggle.isOn == true)
       		{
            		coinstone.allcoin -= 400;
            		toggle.interactable = false;
			c = 1;
        	}	

        
	}
        

      
    }
}
