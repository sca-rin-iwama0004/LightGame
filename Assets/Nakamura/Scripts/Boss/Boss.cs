using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject enemy6r;//right����(��)�̍U��
    [SerializeField] private GameObject enemy6l;//left����(��)�̍U��
    [SerializeField] private GameObject enemy6rd;//enemy6r�̐����ʒu
    [SerializeField] private GameObject enemy6ld;//enemy6l�̐����ʒu
    [SerializeField] private GameObject enemy6R;//right����(��)�̍U��
    [SerializeField] private GameObject enemy6L;//left����(��)�̍U��
    [SerializeField] private GameObject enemy6ru;//enemy6R�̐����ʒu
    [SerializeField] private GameObject enemy6lu;//enemy6L�̐����ʒu
    [SerializeField] private GameObject Coin;
    private float span = 1.0f;
    private float span2 = 1.5f;
    private float span3 = 3.0f;
    private float time1 = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float hp = 1500;
    private float nowhp;
    private int o2d = 0;
    private int o2u = 0;
    private int o2r = 0;
    private int o2l = 0;
    Rigidbody2D rb;
    private float arealr = 0.0f;//�U���͈�(���E)
    private float areaud = 0.0f;//�U���͈�(�㉺)
    public Slider hpSlider;
    private int counter = 0;
    private float move = 0.05f;
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
        hpSlider.value = 1000;
    }

    void Update()
    {
        Vector3 p = new Vector3(move,0,0);
        transform.Translate(p);
        counter++;
        if (counter == 500)
        {
            move *= -1;
        }
        else if(counter == 1500)
        {
            counter = 0;
        }
        else if (counter == 2000)
        {
            counter = 0;
        }
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        recovery();
        //�v���C���[���͈͂ɓ�������ʒu�����߁A���Ԃ��v��
        if (arealr < 60.0f && arealr > -60.0f)
        {
            if (areaud < 60.0f && areaud > -60.0f)
            {
                float x = this.transform.position.x;
                float y = this.transform.position.y;
                time1 += Time.deltaTime;
                time2 += Time.deltaTime;
                time3 += Time.deltaTime;
                //span3�b�o�߂�����enemyshotR�`enemyshotD�𐶐�
                if (time3 > span3 && this.tag != "explosion")
                {
                    Instantiate(enemyshotR);
                    Instantiate(enemyshotL);
                    Instantiate(enemyshotU);
                    Instantiate(enemyshotD);
                    enemyshotR.transform.position = new Vector2(x, y);
                    enemyshotL.transform.position = new Vector2(x, y);
                    enemyshotU.transform.position = new Vector2(x, y);
                    enemyshotD.transform.position = new Vector2(x, y);
                    time3 = 0f;
                }
                //span�b�o�߂�����enemy6r,enemy6L�̐���
                if (time1 > span && this.tag != "explosion")
                {
                    Instantiate(enemy6r);
                    Instantiate(enemy6L);
                    enemy6r.transform.position = enemy6rd.transform.position;
                    enemy6L.transform.position = enemy6lu.transform.position;
                    time1 = 0f;

                }
                //span2�b�o�߂�����enemy6l,enemy6R�̐���
                if (time2 > span2 && this.tag != "explosion")
                {
                    Instantiate(enemy6l);
                    Instantiate(enemy6R);
                    enemy6l.transform.position = enemy6ld.transform.position;
                    enemy6R.transform.position = enemy6ru.transform.position;
                    time2 = 0f;
                }
            }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            hp -= script.Power;
            hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Gun")
        {
            hp -= (script.Power / 2);
            hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Explosion")
        {
            hp -= 50;
            hpSlider.value = hp;
        }

        if (hp <= 0)
        {
            MainSpriteRenderer.sprite = explosion;
            this.tag = "explosion";
            Invoke("End", 2.0f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
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
            Invoke("End", 2.0f);
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


    void End()
    {
        SceneManager.LoadScene("Clear");
        this.gameObject.SetActive(false);
    }
}
