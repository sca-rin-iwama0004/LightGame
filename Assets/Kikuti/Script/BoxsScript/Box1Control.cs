using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Control : MonoBehaviour
{
    //通常宝箱

    public GameObject attackUpBook;
    public GameObject attackSpeedBook;
    public GameObject defenseBook;
    public GameObject attackRangeBook;
    public GameObject speedBook;

    public GameObject stone;

    private bool decision = true;//ドロップアイテム確定までの判定

    //効果音
    public GameObject openSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
           Drop1();

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Drop1();

        }

    }

    private void Stone()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(stone, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        }


    }

    public void Drop1()
    {
        Instantiate(openSound, this.transform.position, this.transform.rotation);//効果音
        Destroy(gameObject);

        int i = 0;//while内をループするための処理
        while (decision = true)
        {
            float rnd = Random.Range(0, 1f);

            //攻撃範囲UPを買っていないならドロップ数＝0に設定
            if (PlayerControl.shopRange == false)
            {
                GameManager.attackRange = 0;
            }
            //防御力UPを買っていないならドロップ数＝0に設定
            if (PlayerControl.shopDefense == false)
            {
                GameManager.defenseUp = 0;
            }

            //すべての強化本のドロップ数が上限を超えたら資源を落とす
            if (GameManager.attackUp == 0 && GameManager.attackSpeedUp == 0 && GameManager.speedUp == 0 && GameManager.attackRange == 0 && GameManager.defenseUp == 0)
            {
                Stone();
                break;
            }
            //攻撃力UPドロップ
            if (rnd <= 0.3f)
            {
                if (GameManager.attackUp > 0)
                {
                    Instantiate(attackUpBook, this.transform.position, this.transform.rotation);
                    GameManager.attackUp -= 1;
                    break;

                }
                else { i += 1; }//while内をループするための処理

            }
            //攻撃速度UPドロップ
            else if (rnd <= 0.5f)
            {
                if (GameManager.attackSpeedUp > 0)//ドロップ数上限超えてなければ実行
                {
                    Instantiate(attackSpeedBook, this.transform.position, this.transform.rotation);
                    GameManager.attackSpeedUp -= 1;
                    break;
                }
                else { i += 1; }
            }
            //移動速度UPドロップ
            else if (rnd <= 0.7f)
            {
                if (GameManager.speedUp > 0)//ドロップ数上限超えてなければ実行
                {
                    Instantiate(speedBook, this.transform.position, this.transform.rotation);
                    GameManager.speedUp -= 1;
                    break;
                }
                else { i += 1; }
            }
            //攻撃範囲UPドロップ
            else if (rnd <= 0.8f)
            {
                if (PlayerControl.shopRange == true)//ショップで購入していれば実行
                {
                    if (GameManager.attackRange > 0)//ドロップ数上限超えてなければ実行
                    {
                        Instantiate(attackRangeBook, this.transform.position, this.transform.rotation);
                        GameManager.attackRange -= 1;
                        break;
                    }
                    else { i += 1; }
                }
            }
            //防御力UPドロップ
            else
            {
                if (PlayerControl.shopDefense == true)//ショップで購入していれば実行
                {
                    if (GameManager.defenseUp > 0)//ドロップ数上限超えてなければ実行
                    {
                        Instantiate(defenseBook, this.transform.position, this.transform.rotation);
                        GameManager.defenseUp -= 1;
                        break;
                    }
                    else { i += 1; }
                }
            }


        }
    }
}
