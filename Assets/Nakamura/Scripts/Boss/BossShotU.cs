using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotU : MonoBehaviour
{
    private float speed = 0.05f;
    GameObject boss;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        float x = boss.transform.position.x;
        float y = boss.transform.position.y;
        transform.position += new Vector3(0.0f, speed, 0.0f);
        if (this.transform.position.y >= y + 45.0f)
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
