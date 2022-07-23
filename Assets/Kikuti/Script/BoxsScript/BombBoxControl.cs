using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoxControl : MonoBehaviour
{
    //”š’eŠm’è•ó” 

    public GameObject bomb;

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

            Instantiate(bomb, this.transform.position, this.transform.rotation); //”š’e

        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.tag == "Player")
        {
            Instantiate(openSound, this.transform.position, this.transform.rotation);//Œø‰Ê‰¹
            Destroy(gameObject);

            Instantiate(bomb, this.transform.position, this.transform.rotation); //”š’e

        }
    }
}
