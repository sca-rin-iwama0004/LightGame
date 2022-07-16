using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeft : MonoBehaviour
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
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
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
        //Debug.Log(areaud);
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        if (arealr < 26.0f && arealr > -1.0f)
        {
            if (areaud < 15.0f && areaud > -15.0f)
            {
                float x = this.transform.position.x+3;
                float y = this.transform.position.y;
                if (MainSpriteRenderer.sprite == enemy3 && en < 1)
                {
                    GetComponent<AudioSource>().Play();
                    Instantiate(enemy4);
                    en++;
                    enemy4.transform.position = new Vector2(x, y);

                }

                if (MainSpriteRenderer.sprite == eye)
                {
                    en = 0;
                }
            }

        }
    }
}
