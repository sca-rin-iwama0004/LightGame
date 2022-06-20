using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinstone : MonoBehaviour
{
    [SerializeField] private Text coinstoneText;
    public static int allcoin =0;
    int all = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StoneText.assetCoin);
	    all = PlayerControl.coin+ (StoneText.assetCoin* 3);
	    coinstoneText.text ="合計コイン　"+ all.ToString();
        allcoin += PlayerControl.coin;
        allcoin += (StoneText.assetCoin* 3);
        Debug.Log(allcoin);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl.coin = 0;
        StoneText.assetCoin = 0;
        all = 0;
    }
}
