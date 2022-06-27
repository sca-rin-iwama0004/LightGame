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
	    if(a == 0)
        {
		    if (coinstone.allcoin < 500)
            { 
                	toggle.isOn = false;
            }
        
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
