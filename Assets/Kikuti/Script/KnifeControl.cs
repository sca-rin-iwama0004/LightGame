using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
    //ナイフ攻撃

    GameObject player;
    PlayerControl script;
    private float moveSpeed; //ナイフ飛ぶ速度
    private int dir;//攻撃方向

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
        moveSpeed=script.GunSpeed;  //ナイフ飛ぶ速度

        dir= (int)script.Direction;//方向確定

        //弾サイズ変更（攻撃範囲）
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
        //ナイフ発射
        if (dir == (int)PlayerControl.PlayerDirection.RIGHT)//右
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            renderer.flipX = true;
        }
        else if (dir == (int)PlayerControl.PlayerDirection.LEFT)//左
        {
            transform.Translate( -moveSpeed * Time.deltaTime , 0, 0);
            renderer.flipX = false;
        }
        else if (dir == (int)PlayerControl.PlayerDirection.UP)//上
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.Translate( -moveSpeed * Time.deltaTime,0 , 0);
        }
        else if (dir == (int)PlayerControl.PlayerDirection.DOWN)//下
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.Translate(-moveSpeed * Time.deltaTime ,0, 0);
            
        }

       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //ナイフ消滅
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Door" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" || other.gameObject.tag == "Enemy4" || other.gameObject.tag == "Enemy5" || other.gameObject.tag == "DieEnemy" || other.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }

    }

    
}
