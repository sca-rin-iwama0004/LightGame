using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    //銃攻撃

    GameObject player;
    PlayerControl script;
    private float moveSpeed;  //弾飛ぶ速度
    private int dir;//攻撃方向

    //攻撃範囲
    private float posX, posY;

    //効果音
    public GameObject bulletSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        moveSpeed = script.GunSpeed;

        dir = (int)script.Direction;//方向確定

        //ナイフサイズ変更（攻撃範囲）
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

        //弾発射
        if (dir == (int)PlayerControl.PlayerDirection.RIGHT)//右
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (dir == (int)PlayerControl.PlayerDirection.LEFT)//左
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (dir == (int)PlayerControl.PlayerDirection.UP)//上
        {
            transform.Translate(0,moveSpeed * Time.deltaTime, 0);
        }
        else if (dir == (int)PlayerControl.PlayerDirection.DOWN)//下
        {
            transform.Translate(0,-moveSpeed * Time.deltaTime, 0);

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //弾消滅
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Door" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" || other.gameObject.tag == "Enemy4" || other.gameObject.tag == "Enemy5" || other.gameObject.tag == "DieEnemy" || other.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }

    }
}
