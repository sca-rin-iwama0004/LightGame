using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    [SerializeField] private Text coinText;
   
    // Start is called before the first frame update
    void Start()
    {
        //¡‰ñŠl“¾‚µ‚½ƒRƒCƒ“‚Ì–‡”‚ğ•\¦
        coinText.text = PlayerControl.coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}