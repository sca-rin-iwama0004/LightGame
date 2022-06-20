using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneText : MonoBehaviour
{
    [SerializeField] private Text stoneText;

    public static int assetCoin = 0;

    // Start is called before the first frame update
    void Start()
    {
        stoneText.text = assetCoin.ToString();
  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
