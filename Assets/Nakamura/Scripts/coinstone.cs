using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinstone : MonoBehaviour
{
    [SerializeField] private Text coinstoneText;
    public static int allcoin = 0;
    int all = 0;
    // Start is called before the first frame update
    void Start()

    { 
	    //all = PlayerControl.coin+ (StoneText.assetCoin*3);
	    coinstoneText.text ="‡ŒvƒRƒCƒ“@"+ allcoin.ToString();
        //allcoin += PlayerControl.coin;
        allcoin += (StoneText.assetCoin*3);

        Debug.Log(allcoin);
    }

    // Update is called once per frame
    void Update()
    {

        StoneText.assetCoin = 0;
        all = 0;
    }
}
