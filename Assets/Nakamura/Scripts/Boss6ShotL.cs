using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss6ShotL : MonoBehaviour
{
    private GameObject boss;
    private float speed = 0.005f;
    float left;
    float down;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
	if(this.transform.position.x >= 0)
	{
		left =(this.transform.position.x*-2)* speed;
        }

	else if(this.transform.position.x < 0)
	{
		left =(this.transform.position.x*2)* speed;
        }


        if(this.transform.position.y >= 0)
	{
		down = (this.transform.position.y*-3)* speed;
        }

	else if(this.transform.position.y < 0)
	{
		down =(this.transform.position.y*3)* speed;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(left, down, 0.0f);
        float x = boss.transform.position.x;
        float y = boss.transform.position.y;
        if (this.transform.position.x >= x + 10.0f || this.transform.position.x < x - 10.0f || this.transform.position.y >= y + 10.0f || this.transform.position.y < y - 10.0f)
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