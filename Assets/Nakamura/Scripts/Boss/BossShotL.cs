using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotL : MonoBehaviour
{
    private float speed = 0.005f;
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
        transform.position += new Vector3(-speed, 0.0f, 0.0f);
        if (this.transform.position.x <= x - 10.0f)
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