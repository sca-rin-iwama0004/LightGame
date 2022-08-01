using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText2 : MonoBehaviour
{
    [SerializeField] private Text coinText;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
       //すべてのコインの合計を表示
       coinText.text = coinstone.allcoin.ToString();
       
    }
}

