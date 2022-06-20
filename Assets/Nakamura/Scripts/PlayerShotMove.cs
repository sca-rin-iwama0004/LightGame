using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0.0f, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            this.gameObject.SetActive(false);
        }
            
    }
}
