using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerControl : MonoBehaviour
{
    

    [SerializeField] private Transform playerTrans;
    [SerializeField] private float speed;

    private float interval=4;//í«è]ä‘äu

    private float timeGun = 4;//çUåÇë¨ìx
    private float timeElapsed;
    public GameObject partnerGun;

    GameObject player;
    PlayerControl script;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();


    }

    // Update is called once per frame
    void Update()
    {
        int dir;
        if (script.OnParther == true) {
            dir = script.Direction;

            //çUåÇ
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeGun)
            {
               Instantiate(partnerGun, transform.position, transform.rotation);
               timeElapsed = 0.0f;
            }

            //à⁄ìÆ
            if (dir == 1)
            {
                this.transform.position =
                  Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x - interval, playerTrans.position.y + interval), speed);
               
            }
            else if (dir == 2)
            {
                this.transform.position =
                  Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x + interval, playerTrans.position.y - interval), speed);
                
            }
            else if (dir == 3)
            {
                this.transform.position =
                  Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x - interval, playerTrans.position.y - interval), speed);
                
            }
            else if (dir == 4)
            {
                this.transform.position =
                 Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x + interval, playerTrans.position.y + interval), speed);
                
            }
        }

       

    }
 

}
