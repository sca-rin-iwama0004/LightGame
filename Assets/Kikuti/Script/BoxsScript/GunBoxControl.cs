using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoxControl : MonoBehaviour
{
    //èeämíËïÛî†

    public GameObject gun;

    //äJÇ≠å¯â âπ
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
            Instantiate(openSound, this.transform.position, this.transform.rotation);//å¯â âπ
            Destroy(gameObject);

            Instantiate(gun, this.transform.position, this.transform.rotation); //èe

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(openSound, this.transform.position, this.transform.rotation);//å¯â âπ
            Destroy(gameObject);

            Instantiate(gun, this.transform.position, this.transform.rotation); //èe

        }

    }
}
