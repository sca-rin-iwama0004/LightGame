using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coinshop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClickStartButton()
    {
        //CoinShop‚ÖƒV[ƒ“ˆÚ“®‚·‚é
        SceneManager.LoadScene("CoinShop");
    }
}
