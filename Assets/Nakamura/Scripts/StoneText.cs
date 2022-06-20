using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneText : MonoBehaviour
{
    [SerializeField] private Text stoneText;
    public static int assetCoin;
    // Start is called before the first frame update
    void Start()
    {
        stoneText.text = PlayerControl.asset.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
