using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game: MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(coinstone.allcoin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickStartButton()
    {
        
        SceneManager.LoadScene("SampleScene");
        if (book1.shopDefense == true)
        {
            //Debug.Log("a");
        }
        else
        {
            //Debug.Log("b");
        }
    }	
}
