using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove5 : MonoBehaviour
{
    GameObject enemy5;
    Rigidbody2D rb;
    private float Speed = 30;
    float m = 0.0f;
    float n = 0.0f;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        enemy5 = GameObject.Find("Enemy5");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y), Speed * Time.deltaTime);
        if (this.transform.position.x > enemy5.transform.position.x + 45.0f || this.transform.position.x < enemy5.transform.position.x - 45.0f || this.transform.position.y > enemy5.transform.position.y + 45.0f || this.transform.position.y < enemy5.transform.position.y - 45.0f)
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
