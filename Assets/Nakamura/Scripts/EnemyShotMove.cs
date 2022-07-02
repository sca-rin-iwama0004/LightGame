using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMove : MonoBehaviour
{
    private float speed =0.004f;    
    float n;
    Rigidbody2D rb;
    [SerializeField] private GameObject enemy1;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; 
        n = player.transform.position.x * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = enemy1.transform.position.x;
        float y = enemy1.transform.position.y;
        transform.position += new Vector3(n, 0.0f, 0.0f);
	    if (this.transform.position.x >= x + 50.0f || this.transform.position.x <= x - 50.0f || this.transform.position.y >= y + 50.0f || this.transform.position.y <= y - 30.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
