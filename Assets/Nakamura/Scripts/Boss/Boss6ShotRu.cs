using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss6ShotRu : MonoBehaviour
{
    private GameObject boss;
    private float speed = 0.005f;
    float right;
    float up;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        boss = GameObject.Find("Boss");
        if (this.transform.position.x >0)
        {
            right = (this.transform.position.x * 2) * speed;
        }

        else
        {
            right = (this.transform.position.x * -2) * speed;
        }

        if (this.transform.position.y > 0)
        {
            up = (this.transform.position.y * 3) * speed;
        }

        else
        {
           up = (this.transform.position.y * -3) * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(right, up, 0.0f);
        float x = boss.transform.position.x;
        float y = boss.transform.position.y;
        if (this.transform.position.x >= x + 45.0f || this.transform.position.x < x - 45.0f || this.transform.position.y >= y + 45.0f || this.transform.position.y < y - 45.0f)
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