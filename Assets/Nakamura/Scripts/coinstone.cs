using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinstone : MonoBehaviour
{
    [SerializeField] private Text coinstoneText;
    public static int allcoin =0;//すべてのコインの枚数
    int all = 0;//今回獲得したコインの合計
    // Start is called before the first frame update
    void Start()
    { 
	    all = PlayerControl.coin+ (PlayerControl.asset * 3);//allに獲得したコインと資源を3倍したものを足す
        allcoin += PlayerControl.coin;//allcoinに獲得したコインを足す
        allcoin += (PlayerControl.asset * 3);//allcoinに獲得した資源を3倍したものを足す
        coinstoneText.text = allcoin.ToString();//allcoinを表示
        //Debug.Log(allcoin);
    }

    // Update is called once per frame
    void Update()
    {
        //今回獲得したコイン、資源、今回のコインの合計を消す
        PlayerControl.coin = 0;
        PlayerControl.asset = 0;
        all = 0;
    }
}
