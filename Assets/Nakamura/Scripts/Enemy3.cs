using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite eye;
    [SerializeField] private Sprite enemy3;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Food;
    [SerializeField] private GameObject Silver;
    private float time = 0f;
    private int sleep = 3;
    private int hp =5;
    Rigidbody2D rb;
    GameObject player;
    [SerializeField] private GameObject enemy4;
    int en =0;
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
        pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time%10 <=sleep)
        {
            MainSpriteRenderer.sprite = enemy3;

        }

        else
        {
            MainSpriteRenderer.sprite = eye;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp--;
        }

        if (hp <= 0)
        {
                this.gameObject.SetActive(false);
        }
    }
  
    void OnTriggerStay2D(Collider2D other)
    {
        float x = Random.Range(pos.x + 3, pos.x - 3);
        float y = Random.Range(pos.x -2, pos.x - 6);
        if (other.gameObject.tag == "Player" && MainSpriteRenderer.sprite == enemy3 && en <1)
        {
            Instantiate(enemy4);
            en++;
            enemy4.transform.position = new Vector2(x, y);

        }

        if (MainSpriteRenderer.sprite == eye)
        {
            en =0;
        }
    }
}
