using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box4Control : MonoBehaviour
{
    //ƒŒƒA•ó” 

    public GameObject hpUpBook;
    public GameObject o2UpBook;
    public GameObject attackRangeBook;
    public GameObject attackSpeedBook;
    public GameObject hpRecoveryBook;

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
            float rnd = Random.Range(0, 1f);
            Destroy(gameObject);

            if (rnd <= 0.2f)
            {
                Instantiate(hpUpBook, this.transform.position, this.transform.rotation);

                //HPUP
            }
            else if(rnd <= 0.4f)
            {
                Instantiate(o2UpBook, this.transform.position, this.transform.rotation);
                //Ž_‘f‘Ï‹vUP
            }
            else if (rnd <= 0.6f)
            {
                Instantiate(attackRangeBook, this.transform.position, this.transform.rotation);
                //UŒ‚”ÍˆÍUP
            }
            else if (rnd <= 0.8f)
            {
                Instantiate(attackSpeedBook, this.transform.position, this.transform.rotation);
                //UŒ‚‘¬“xUP
            }
            else
            {
                Instantiate(hpRecoveryBook, this.transform.position, this.transform.rotation);
                //Ž©“®‰ñ•œ
            }
        }

    }
}
