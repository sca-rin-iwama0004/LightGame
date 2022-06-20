using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{

    GameObject player;
    PlayerControl script;
    int dir;
    float moveSpeed;

    //攻撃範囲
    BoxCollider2D boxCol;
    private float range;
    private float posX,posY;

    //画像
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        dir = script.Direction;
        moveSpeed=script.GunSpeed;

        boxCol=GetComponent<BoxCollider2D>();
        posX = boxCol.size.x;
        posY=boxCol.size.y;



        //画像
        renderer = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        if (dir == 1)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            renderer.flipX = true;
        }
        else if (dir == 2)
        {
            transform.Translate( -moveSpeed * Time.deltaTime , 0, 0);
            renderer.flipX = false;
        }
        else if (dir == 3)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.Translate( -moveSpeed * Time.deltaTime,0 , 0);
        }
        else if (dir == 4)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.Translate(-moveSpeed * Time.deltaTime ,0, 0);
            
        }

        boxCol.size = new Vector3(posX + script.Range, posY + script.Range, script.Range);
    


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Partner")
        {
            Destroy(gameObject);
        }

    }

    
}
