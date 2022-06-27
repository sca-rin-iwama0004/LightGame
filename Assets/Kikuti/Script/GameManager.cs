using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ƒhƒƒbƒvãŒÀŠÇ—

    GameObject player;
    PlayerControl script;


    public static int attackUp=12;//UŒ‚—Í@
    public static int attackSpeedUp=5;//UŒ‚‘¬“x
    public static int speedUp=10;//ˆÚ“®‘¬“x
    public static int jumpUp=1;//ƒWƒƒƒ“ƒv
    public static int hpUp=10;//HP
    public static int o2Up=5;//_‘fŒ¸­—¦
    public static int defenseUp=10;//–hŒä—Í
    public static int attackRange=10;//UŒ‚”ÍˆÍ
    public static int hpRecUp=1;//©“®‰ñ•œ


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();


    }

    // Update is called once per frame
    void Update()
    {
       
    }

}

