using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box4Control : MonoBehaviour
{
    //ƒŒƒA•ó” 

    public GameObject hpUpBook;
    public GameObject o2UpBook;
    public GameObject hpRecoveryBook;

    public GameObject stone;

    private bool decision = true;

    //ŠJ‚­Œø‰Ê‰¹
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
            Instantiate(openSound, this.transform.position, this.transform.rotation);//Œø‰Ê‰¹
            Destroy(gameObject);

            int i = 0;
            while (decision == true)
            {

                float rnd = Random.Range(0, 1f);

                if (PlayerControl.shopRec == false)
                {
                    GameManager.hpRecUp = 0;
                }

                if (GameManager.hpUp == 0 && GameManager.o2Up == 0 && GameManager.hpRecUp == 0)
                {
                    Stone();
                    break;
                }

                if (rnd <= 0.3f)//HPUP
                {
                    if(GameManager.hpUp>0)
                    {
                        Instantiate(hpUpBook, this.transform.position, this.transform.rotation);
                        GameManager.hpUp-=1;
                        decision=false;
                    }
                    else { i += 1; }

                }
                else if (rnd <= 0.6f)//Ž_‘fŒ¸­—¦
                {
                    if (GameManager.o2Up > 0)
                    {
                        Instantiate(o2UpBook, this.transform.position, this.transform.rotation);
                        GameManager.o2Up-=1;
                        decision=false;
                    }
                    else { i += 1; }
                }
                else//Ž©“®‰ñ•œ
                {
                    if (PlayerControl.shopRec == true)
                    {
                        if (GameManager.hpRecUp > 0)
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

    private void Stone()
    {
        for(int i=0;i<10;i++)
        {
            Instantiate(stone, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), this.transform.rotation);
        }
        

    }
    
}
