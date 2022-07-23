using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    private float speed = 0.1f;
    float n;
    Rigidbody2D rb;
    [SerializeField] private GameObject player;
    private float Speed =30;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    GameObject enemy4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        enemy4 = GameObject.Find("Enemy4");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y), Speed * Time.deltaTime);
        if (this.transform.position.x > enemy4.transform.position.x + 45.0f || this.transform.position.x < enemy4.transform.position.x - 45.0f || this.transform.position.y > enemy4.transform.position.y + 45.0f || this.transform.position.y < enemy4.transform.position.y - 45.0f)
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
