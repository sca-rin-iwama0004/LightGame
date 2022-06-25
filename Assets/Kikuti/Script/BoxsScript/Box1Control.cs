using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Control : MonoBehaviour
{
    //í èÌïÛî†

    public GameObject attackUpBook;
    public GameObject attackSpeedBook;
    public GameObject defenseBook;
    public GameObject attackRangeBook;
    public GameObject speedBook;

    public GameObject stone;

    private bool decision = true;

    //å¯â âπ
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
            Instantiate(openSound, this.transform.position, this.transform.rotation);//å¯â âπ
            Destroy(gameObject);

            int i=0;
            while (decision = true)
            {
                float rnd = Random.Range(0, 1f);

                if (PlayerControl.shopRange == false)
                {
                    GameManager.attackRange=0;
                }
                if (PlayerControl.shopDefense == false)
                {
                    GameManager.defenseUp=0;
                }


                if (GameManager.attackUp==0&& GameManager.attackSpeedUp == 0 && GameManager.speedUp == 0 && GameManager.attackRange == 0 && GameManager.defenseUp == 0 )
                { 
                    Stone();
                    break;
                }
                if (rnd <= 0.3f) //çUåÇóÕUP
                {
                    if (GameManager.attackUp > 0)
                    {
                        Instantiate(attackUpBook, this.transform.position, this.transform.rotation);
                        GameManager.attackUp -= 1;
                        break;

                    }
                    else { i+=1;}
                    
                }
                else if (rnd <= 0.5f)//çUåÇë¨ìxUP
                {
                    if (GameManager.attackSpeedUp > 0)
                    {
                        Instantiate(attackSpeedBook, this.transform.position, this.transform.rotation);
                        GameManager.attackSpeedUp -= 1;
                        break;
                    }
                    else { i += 1; }
                }
                else if (rnd <= 0.7f)//à⁄ìÆë¨ìxUP
                {
                    if (GameManager.speedUp > 0)
                    {
                        Instantiate(speedBook, this.transform.position, this.transform.rotation);
                        GameManager.speedUp -= 1;
                        break;
                    }
                    else { i += 1; }
                }
                else if (rnd <= 0.8f)//çUåÇîÕàÕUP
                {
                    if (PlayerControl.shopRange == true)
                    {
                        if (GameManager.attackRange > 0)
                        {
                            Instantiate(attackRangeBook, this.transform.position, this.transform.rotation);
                            GameManager.attackRange -= 1;
                            break;
                        }
                        else { i += 1; }
                    }
                }
                else//ñhå‰óÕUP
                {
                    if (PlayerControl.shopDefense == true)
                    {
                        if (GameManager.defenseUp > 0)
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
    private void Stone()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(stone, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        }


    }
}
