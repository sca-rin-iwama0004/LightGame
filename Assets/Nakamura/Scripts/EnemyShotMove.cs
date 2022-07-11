using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMove : MonoBehaviour
{
    private float speed =0.001f;    
    float n;
    Rigidbody2D rb;
    [SerializeField] private GameObject enemy1;
    GameObject player;
    float m;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        n = player.transform.position.x * speed;
        m = this.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(n, 0.0f, 0.0f);
        if (this.transform.position.x >= m + 100.0f || this.transform.position.x <= m - 100.0f)
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
