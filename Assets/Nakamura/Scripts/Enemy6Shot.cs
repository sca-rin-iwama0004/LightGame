using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Shot : MonoBehaviour
{
    private GameObject enemy6l;
    private GameObject enemy5;
    private float speed = 0.0009f;
    float right;
    float up;
    // Start is called before the first frame update
    void Start()
    {
        enemy6l = GameObject.Find("Enemy6ShotLh");
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
            up= (this.transform.position.y * -2) * speed;
            
        }

        else
        {
            up = (this.transform.position.y * 2) * speed;
            Debug.Log("a");
        }


    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-right, -up, 0.0f);
        float x = enemy6l.transform.position.x;
        float y = enemy6l.transform.position.y;
        if (this.transform.position.x >= x + 11.0f || this.transform.position.x <= x - 10.0f || this.transform.position.y >= y + 10.0f || this.transform.position.y <= y - 10.0f)
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
