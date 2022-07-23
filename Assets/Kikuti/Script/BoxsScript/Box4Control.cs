using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box4Control : MonoBehaviour
{
    //レア宝箱

    public GameObject hpUpBook;
    public GameObject o2UpBook;
    public GameObject hpRecoveryBook;

    public GameObject stone;

    private bool decision = true; //ドロップアイテム確定までの判定

    //開く効果音
    public GameObject openSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Drop4();   
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Drop4();
        }
    }

    private void Stone()
    {
        for(int i=0;i<10;i++)
        {
            Instantiate(stone, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), this.transform.rotation);
        }
        

    }

    public void Drop4()
    {
        Instantiate(openSound, this.transform.position, this.transform.rotation);//効果音
        Destroy(gameObject);

        int i = 0; //while内をループするための処理
        while (decision == true)
        {

            float rnd = Random.Range(0, 1f);

            //HP自動回復を買っていないならドロップ数＝0に設定
            if (book3.shopRec == false)
            {
                GameManager.hpRecUp = 0;
            }
            //すべての強化本のドロップ数が上限を超えたら資源を落とす
            if (GameManager.hpUp == 0 && GameManager.o2Up == 0 && GameManager.hpRecUp == 0)
            {
                Stone();
                break;
            }
            //HPUPドロップ
            if (rnd <= 0.3f)
            {
                if (GameManager.hpUp > 0)//ドロップ数上限超えてなければ実行
                {
                    Instantiate(hpUpBook, this.transform.position, this.transform.rotation);
                    GameManager.hpUp -= 1;
                    decision = false;
                }
                else { i += 1; }//while内をループするための処理

            }
            //酸素減少率ドロップ
            else if (rnd <= 0.6f)
            {
                if (GameManager.o2Up > 0)//ドロップ数上限超えてなければ実行
                {
                    Instantiate(o2UpBook, this.transform.position, this.transform.rotation);
                    GameManager.o2Up -= 1;
                    decision = false;
                }
                else { i += 1; }
            }
            //自動回復ドロップ
            else
            {
                if (book3.shopRec == true)//ショップで購入していれば実行
                {
                    if (GameManager.hpRecUp > 0)//ドロップ数上限超えてなければ実行
                    {
                        Instantiate(hpRecoveryBook, this.transform.position, this.transform.rotation);
                        GameManager.hpRecUp -= 1;
                        decision = false;
                    }
                    else { i += 1; }
                }
            }
        }
    }
    
}
