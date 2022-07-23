using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5ShotL : MonoBehaviour
{
    private float speed = 0.1f;
    GameObject enemy4;
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");
    }

    // Update is called once per frame
    void Update()
    {
        float x = enemy4.transform.position.x;
        float y = enemy4.transform.position.y;
        transform.position += new Vector3(-speed, 0.0f, 0.0f);
        if (this.transform.position.x <= x - 45.0f)
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
