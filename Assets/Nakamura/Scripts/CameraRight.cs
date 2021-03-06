using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRight : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite eye;//目が閉じてる敵画像
    [SerializeField] private Sprite enemy3;//目が開いてる敵画像
    [SerializeField] private GameObject enemy4;//出現させる敵
    private float time = 0f;
    private int sleep = 3;//画像切り替えの間隔
    Rigidbody2D rb;
    GameObject player;
    int en = 0;
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
        if (time % 10 <= sleep)
        {
            MainSpriteRenderer.sprite = enemy3;

        }

        else
        {
            MainSpriteRenderer.sprite = eye;
        }
        //Debug.Log(arealr);
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        if (arealr < 1.0f && arealr > -26.0f)
        {
            if (areaud < 15.0f && areaud > -15.0f)
            {
                float x = this.transform.position.x - 3;
                float y = this.transform.position.y ;
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
