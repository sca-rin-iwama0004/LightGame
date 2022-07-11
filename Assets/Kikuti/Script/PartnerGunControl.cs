using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerGunControl : MonoBehaviour
{
    //íáä‘çUåÇ

    GameObject player;
    PlayerControl script;
    private float moveSpeed=20;  //íeë¨ìx
    private int dir;//çUåÇï˚å¸

    //å¯â âπ
    public GameObject bulletSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

        dir = (int)script.Direction;//ï˚å¸ämíË

        Instantiate(bulletSound, this.transform.position, this.transform.rotation);//å¯â âπ
    }

    // Update is called once per frame
    void Update()
    {
        //çUåÇ
        if (dir == (int)PlayerControl.PlayerDirection.RIGHT)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (dir == (int)PlayerControl.PlayerDirection.LEFT)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (dir == (int)PlayerControl.PlayerDirection.UP)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
        else if (dir == (int)PlayerControl.PlayerDirection.DOWN)
        {
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //íeè¡ñ≈
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Partner" && other.gameObject.tag != "Bullet"&& other.gameObject.tag != "Untagged" && other.gameObject.tag != "Gun" && other.gameObject.tag != "Hole" && other.gameObject.tag != "Road" && other.gameObject.tag != "Bombs" && other.gameObject.tag != "JumpRang")
        {
           
            Destroy(gameObject);
        }

    }
}
