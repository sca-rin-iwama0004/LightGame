using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6ShotR : MonoBehaviour
{
    private GameObject enemy6r;
    private float speed = 0.0009f;
    float right;
    float down;
    // Start is called before the first frame update
    void Start()
    {
        enemy6r = GameObject.Find("Enemy6ShotR");
        if (this.transform.position.x > 0)
        {
            right = (this.transform.position.x * 2) * speed;
        }

        else if (this.transform.position.x < 0)
        {
            right = (this.transform.position.x * -2) * speed;
        }

        if (this.transform.position.y > 0)
        {
            down = (this.transform.position.y * -2) * speed;
        }

        else if (this.transform.position.y < 0)
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
