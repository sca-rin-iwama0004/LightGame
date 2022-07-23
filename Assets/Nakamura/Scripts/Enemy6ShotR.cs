using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6ShotR : MonoBehaviour
{
    private GameObject enemy6r;
    private GameObject enemy5;
    private float speed = 0.0009f;
    float right;
    float down;
    // Start is called before the first frame update
    void Start()
    {
        enemy6r = GameObject.Find("Enemy6ShotRh");
        enemy5 = GameObject.Find("Enemy5");
        if (this.transform.position.x >= enemy5.transform.position.x)
        {
            right = (this.transform.position.x * 2) * speed;
        }

        else
        {
            right = (this.transform.position.x * -2) * speed;
        }


        if (this.transform.position.y >= enemy5.transform.position.y)
        {
            down = (this.transform.position.y * -2) * speed;

        }

        else
        {
            down = (this.transform.position.y * 2) * speed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-right, down, 0.0f);
        float x = enemy6r.transform.position.x;
        float y = enemy6r.transform.position.y;
        if (this.transform.position.x >= x + 40.0f || this.transform.position.x <= x - 40.0f || this.transform.position.y >= y + 40.0f || this.transform.position.y <= y - 40.0f)
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
