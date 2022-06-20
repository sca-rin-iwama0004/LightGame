using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    SpriteRenderer MainSpriteRendererD;
    SpriteRenderer MainSpriteRendererU;
    SpriteRenderer MainSpriteRendererR;
    SpriteRenderer MainSpriteRendererL;
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite atk;
    [SerializeField] private Sprite o2up;
    [SerializeField] private Sprite explosion;
    [SerializeField] private GameObject enemyshotR;
    [SerializeField] private GameObject enemyshotL;
    [SerializeField] private GameObject enemyshotU;
    [SerializeField] private GameObject enemyshotD;
    [SerializeField] private GameObject enemy6r;
    [SerializeField] private GameObject enemy6l;
    [SerializeField] private GameObject enemy6rc;
    [SerializeField] private GameObject enemy6lc;
    [SerializeField] private GameObject enemy6ru;
    [SerializeField] private GameObject enemy6lu;
    [SerializeField] private GameObject enemy6rcu;
    [SerializeField] private GameObject enemy6lcu;
    //[SerializeField] private GameObject Coin;
    private float span = 1.0f;
    private float span2 = 1.5f;
    private float time = 0f;
    private float time2 = 0f;
    private float hp = 1000;
    private int o2d = 0;
    private int o2u = 0;
    private int o2r = 0;
    private int o2l = 0;
    Rigidbody2D rb;
   // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        MainSpriteRendererD = enemyshotD.GetComponent<SpriteRenderer>();
        MainSpriteRendererR = enemyshotR.GetComponent<SpriteRenderer>();
        MainSpriteRendererL = enemyshotL.GetComponent<SpriteRenderer>();
        MainSpriteRendererU = enemyshotU.GetComponent<SpriteRenderer>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    void Update()
    {
        recovery();
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        time += Time.deltaTime;
        if (time > span && this.tag != "explosion")
        {
            Instantiate(enemyshotR);
            Instantiate(enemyshotL);
            Instantiate(enemyshotU);
            Instantiate(enemyshotD);
            enemyshotR.transform.position = new Vector2(x, y);
            enemyshotL.transform.position = new Vector2(x, y);
            enemyshotU.transform.position = new Vector2(x, y);
            enemyshotD.transform.position = new Vector2(x, y);
        }
        time2 += Time.deltaTime;
        if (time > span && this.tag != "explosion")
        {
            Instantiate(enemy6r);
            Instantiate(enemy6lu);
            enemy6r.transform.position = enemy6rc.transform.position;
            enemy6lu.transform.position = enemy6lcu.transform.position;
            time = 0f;

        }
        else if (time2 > span2 && this.tag != "explosion")
        {
            Instantiate(enemy6l);
            Instantiate(enemy6ru);
            enemy6l.transform.position = enemy6lc.transform.position;
            enemy6ru.transform.position = enemy6rcu.transform.position;
            time2 = 0f;
        }
    }

    void recovery()
    {
        o2d = Random.Range(1, 11);
        if (o2d >= 9)
        {
            MainSpriteRendererD.sprite = o2up;
            enemyshotD.tag = "O2";
        }

        else
        {
            MainSpriteRendererD.sprite = atk;
            enemyshotD.tag = "Boss";
        }

        o2u = Random.Range(1, 11);
        if (o2u >= 9)
        {
            MainSpriteRendererU.sprite = o2up;
            enemyshotU.tag = "O2";
        }

        else
        {
            MainSpriteRendererU.sprite = atk;
            enemyshotU.tag = "Boss";
        }

        o2r = Random.Range(1, 11);
        if (o2r >= 9)
        {
            MainSpriteRendererR.sprite = o2up;
            enemyshotR.tag = "O2";
        }

        else
        {
            MainSpriteRendererR.sprite = atk;
            enemyshotR.tag = "Boss";
        }

        o2l = Random.Range(1, 11);
        if (o2l >= 9)
        {
            MainSpriteRendererL.sprite = o2up;
            enemyshotL.tag = "O2";
        }

        else
        {
            MainSpriteRendererL.sprite = atk;
            enemyshotL.tag = "Boss";
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
        hp -= script.Power;
        }
        if (other.gameObject.tag == "Gun")
         {
         hp -= (script.Power / 2);
         }
        if (other.gameObject.tag == "Explosion")
         {
         hp -= 50;
        }

        if (hp <= 0)
        {
            MainSpriteRenderer.sprite = explosion;
            this.tag = "explosion";
            Invoke("End",2.0f);
        }
    }

    void End()
    {
        this.gameObject.SetActive(false);
    }
}
