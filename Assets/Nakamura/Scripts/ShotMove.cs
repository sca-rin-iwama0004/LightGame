using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    GameObject player;
    GameObject enemy4;
    Rigidbody2D rb;
    private float speed = 0.004f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
        enemy4 = GameObject.Find("Enemy4");
    }

    // Update is called once per frame
    void Update()
    {
        float x= player.transform.position.x*speed;
        float y = player.transform.position.y*speed;
        transform.position += new Vector3(x,y,0);

        if (enemy4.transform.position.x >this.transform.position.x + 45.0f || enemy4.transform.position.x < this.transform.position.x - 45.0f|| enemy4.transform.position.y > this.transform.position.y + 45.0f || enemy4.transform.position.y < this.transform.position.y - 45.0f)
        {
            
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Partner" || other.gameObject.tag == "Door")
        {
            this.gameObject.SetActive(false);
        }
    }
}
