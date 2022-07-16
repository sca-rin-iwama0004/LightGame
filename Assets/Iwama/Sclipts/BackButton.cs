
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : CheckButton
{
    GameObject number;
    CheckButton script;
 
    public void PushButtonDialBack()
    {

        number = GameObject.Find("Check");
        script = number.GetComponent<CheckButton>();

        
        script.inputString = "";//back‚Ì‚ğíœ‚µ‚Ä‚µ‚Ü‚Á‚Ä‚¢‚é
        suuji_text.text = "";
        Panel.SetActive(false);

        Debug.Log("–ß‚é");
        
    }

}

