using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite eye;//–Ú‚ª•Â‚¶‚Ä‚é“G‰æ‘œ
    [SerializeField] private Sprite enemy3;//–Ú‚ªŠJ‚¢‚Ä‚é“G‰æ‘œ
    [SerializeField] private GameObject enemy4;//oŒ»‚³‚¹‚é“G
    private float time = 0f;
    private int sleep = 3;//‰æ‘œØ‚è‘Ö‚¦‚ÌŠÔŠu
    Rigidbody2D rb;
    GameObject player;
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

  
    void OnTriggerStay2D(Collider2D other)
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y+3;
        if (other.gameObject.tag == "Player" && MainSpriteRenderer.sprite == enemy3 && en <1)
        {
            GetComponent<AudioSource>().Play();
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
