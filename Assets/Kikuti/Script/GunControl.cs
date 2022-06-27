using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    int dir;
    float moveSpeed;

    //攻撃範囲
    private float posX, posY;

    //効果音
    public GameObject bulletSound;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        dir = script.Direction;
        moveSpeed = script.GunSpeed;

        Vector3 size;
        size = gameObject.transform.localScale;
        size.x += (script.Range/10);
        size.y += (script.Range/10);
        gameObject.transform.localScale = size;

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
            transform.Translate(0,moveSpeed * Time.deltaTime, 0);
        }
        else if (dir == 4)
        {
            transform.Translate(0,-moveSpeed * Time.deltaTime, 0);

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Partner"&& other.gameObject.tag != "Untagged" && other.gameObject.tag != "Gun"&& other.gameObject.tag != "Hole" && other.gameObject.tag != "Road" && other.gameObject.tag != "Bombs")
        {
            Destroy(gameObject);
        }

    }
}
