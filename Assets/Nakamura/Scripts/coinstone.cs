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
	    all = PlayerControl.coin+ (PlayerControl.asset * 3);
        allcoin += PlayerControl.coin;
        allcoin += (PlayerControl.asset * 3);
        coinstoneText.text = allcoin.ToString();
        Debug.Log(allcoin);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl.coin = 0;
        PlayerControl.asset = 0;
        all = 0;
    }
}
