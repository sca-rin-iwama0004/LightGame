using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ƒhƒƒbƒvãŒÀŠÇ—

    GameObject player;
    PlayerControl script;


    public static int attackUp;//UŒ‚—Í@
    public static int attackSpeedUp;//UŒ‚‘¬“x
    public static int speedUp;//ˆÚ“®‘¬“x
    public static int jumpUp;//ƒWƒƒƒ“ƒv
    public static int hpUp;//HP
    public static int o2Up;//_‘fŒ¸­—¦
    public static int defenseUp;//–hŒä—Í
    public static int attackRange;//UŒ‚”ÍˆÍ
    public static int hpRecUp;//©“®‰ñ•œ


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

       attackUp = 12;//UŒ‚—Í@
       attackSpeedUp = 5;//UŒ‚‘¬“x
       speedUp = 10;//ˆÚ“®‘¬“x
       jumpUp = 1;//ƒWƒƒƒ“ƒv
       hpUp = 10;//HP
       o2Up = 5;//_‘fŒ¸­—¦
       defenseUp = 10;//–hŒä—Í
       attackRange = 10;//UŒ‚”ÍˆÍ
       hpRecUp = 1;//©“®‰ñ•œ
}

    // Update is called once per frame
    void Update()
    {
       
    }

}

