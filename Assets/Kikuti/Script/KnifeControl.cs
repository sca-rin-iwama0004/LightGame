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
    private float posX,posY;

    //画像
    private SpriteRenderer renderer;

    //効果音
    public GameObject knifeSound;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        dir = script.Direction;
        moveSpeed=script.GunSpeed;
        
        Vector3 size;
        size = gameObject.transform.localScale;
        size.x += (script.Range/10);
        size.y += (script.Range/10);
        gameObject.transform.localScale = size;


        Instantiate(knifeSound, this.transform.position, this.transform.rotation);//効果音

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

       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Partner" && other.gameObject.tag != "Untagged" && other.gameObject.tag != "Gun" && other.gameObject.tag != "Hole" && other.gameObject.tag != "Road" && other.gameObject.tag != "Bombs" && other.gameObject.tag != "JumpRang")
        {
            Destroy(gameObject);
        }

    }

    
}
