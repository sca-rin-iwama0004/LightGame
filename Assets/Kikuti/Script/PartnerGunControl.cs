using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerGunControl : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    int dir;
    private float moveSpeed=20;

    //効果音
    public GameObject bulletSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        dir = script.Direction;

        Instantiate(bulletSound, this.transform.position, this.transform.rotation);//効果音
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == 1)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (dir == 2)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (dir == 3)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
        else if (dir == 4)
        {
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Partner" && other.gameObject.tag != "Bullet"&& other.gameObject.tag != "Untagged" && other.gameObject.tag != "Gun" && other.gameObject.tag != "Hole" && other.gameObject.tag != "Road" && other.gameObject.tag != "Bombs" && other.gameObject.tag != "JumpRang")
        {
           
            Destroy(gameObject);
        }

    }
}
