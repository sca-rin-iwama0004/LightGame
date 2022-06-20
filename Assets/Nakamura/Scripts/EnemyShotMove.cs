using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMove : MonoBehaviour
{
    private float speed =0.004f;    
    GameObject player;
    GameObject enemy2;
    float n;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
	    enemy2 = GameObject.Find("Enemy2");
        n= player.transform.position.x * speed;
    }

    // Update is called once per frame
    void Update()
    {
	    float x = enemy2.transform.position.x;
        float y = enemy2.transform.position.y;
        transform.position += new Vector3(n, 0.0f, 0.0f);
	  if (this.transform.position.x >= x + 10.0f || this.transform.position.x <= x - 10.0f || this.transform.position.y >= y + 10.0f || this.transform.position.y <= y - 10.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
