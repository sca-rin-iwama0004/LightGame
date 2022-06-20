using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private float speed = 0.005f;
    public GameObject PlayerShot;
    public static int coin =0;
    public static int assetCoin = 0;
    public static int asset = 0;
    private int hp = 10;
    private float power = 5;
    Rigidbody2D rb;
    GameObject boss;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boss = GameObject.Find("Boss");
    }

    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        else if (Input.GetKey("right"))
        {
            position.x += speed;
        }
        else if (Input.GetKey("up"))
        {
            position.y += speed;
        }
        else if (Input.GetKey("down"))
        {
            position.y -= speed;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Shot = Instantiate(PlayerShot);
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            PlayerShot.transform.position = new Vector2(x, y);
        }

        transform.position = position;

        if(boss.activeSelf == false)
        { 
             coin+= 100;
             SceneManager.LoadScene("Clear");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Coin")
        {
            coin+=1;
            Debug.Log(coin);
        }



        if (other.gameObject.tag == "Stone")
        {
            asset++;
            assetCoin++;
            Debug.Log(assetCoin);

        }

        if (other.gameObject.tag == "Shot")
        {
            hp -= 1;
            if(hp <=0)
            {
                SceneManager.LoadScene("GameOver");
                assetCoin = 0;
            }
        }

        if (other.gameObject.tag == "O2" || other.gameObject.tag == "Food")
        {
            hp+=1;
        }

        Debug.Log(hp);
    }

    public float Power
    {
        set { this.power = value; }
        get { return this.power; }
    }
}