using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    private float speed = 0.004f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x= player.transform.position.x*speed;
        float y = player.transform.position.y*speed;
        transform.position += new Vector3(x,y,0);

        if (this.transform.position.x >x + 10.0f || this.transform.position.x <=x - 10.0f || this.transform.position.y >=y + 10.0f || this.transform.position.y <= y - 10.0f)
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
