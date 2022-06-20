using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box3Control : MonoBehaviour
{
    //‘•”õ•ó” 

    public GameObject atUpBook;
    public GameObject atSpeedBook;

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

            float rnd = Random.Range(0, 1f);
            Destroy(gameObject);

            if (rnd <= 0.25)
            {
                Instantiate(atUpBook, this.transform.position, this.transform.rotation);
                //UŒ‚—ÍUP
            }
            else
            {
                Instantiate(atSpeedBook, this.transform.position, this.transform.rotation);
                //UŒ‚‘¬“xUP
            }
        }

    }
}
