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
        Debug.Log(Player.item);
	    all = Player.coin+ Player.item;
	    coinstoneText.text ="合計コイン　"+ all.ToString();
        allcoin += Player.coin;
        allcoin += Player.item;
    }

    // Update is called once per frame
    void Update()
    {
        Player.coin = 0;
        Player.item = 0;
        all = 0;
    }
}
