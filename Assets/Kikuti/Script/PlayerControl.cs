using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //画像
    [SerializeField] private Sprite playerPrevious;
    [SerializeField] private Sprite playerBehind;
    [SerializeField] private Sprite playerSide;

    private SpriteRenderer renderer;
    SpriteRenderer sr;

    //移動
    private float speed=0.003f;                          
    private Rigidbody2D rb;

    //弾
    private int direction = 2;//向いてる方向１～４
    private float gunSpeed=15;                    
    private int gunKind=1;//武器１(ナイフ)2(銃)～ 
    public GameObject knife;
    public GameObject gun;
    private float timeGun=5.0f;  //攻撃速度
    private float range=0; //増加攻撃範囲
    private float power=5; //攻撃力

    //爆弾
    bool getBomb=false;
    public GameObject bombs;
    private float timeBomb=30;//爆弾設置クールタイム                     

    private float timeElapsed;

    //HP酸素
    private float hp=100.0f;
    private float hpLimit = 100.0f;
    private float oxygen=50.0f;
    private bool maxO2=false;
    private bool rec=false;

    private bool onParther = false;//追従開始

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();

        renderer = GetComponent<SpriteRenderer>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        if (horizontalKey > 0)
        {
            rb.position += new Vector2(speed* Input.GetAxis("Horizontal"),0 );
            sr.sprite = playerSide;
            renderer.flipX = true;
            direction = 1;
        }//右-1
        else if (horizontalKey < 0)
        {
            rb.position += new Vector2(speed * Input.GetAxis("Horizontal"), 0);
            sr.sprite = playerSide;
            renderer.flipX = false;
            direction = 2;
        }//左-2

        if (verticalKey > 0)
        {
            rb.position += new Vector2(0,speed * Input.GetAxis("Vertical"));
            sr.sprite = playerBehind;
            direction = 3;
        }//上-3
        else if (verticalKey < 0)
        {
            rb.position += new Vector2(0, speed * Input.GetAxis("Vertical"));
            sr.sprite = playerPrevious;
            direction = 4;
        }//下-4


        //弾
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeGun)
        {
            if (gunKind == 1)//ナイフ
            {
                Instantiate(knife, transform.position, transform.rotation);
            }
            else if (gunKind == 2)//銃
            {
                Instantiate(gun, transform.position, transform.rotation);
            }
           
            timeElapsed = 0.0f;
        }

        //爆弾
        if(Input.GetKeyDown(KeyCode.Space)){
            if (getBomb == true) {
                Instantiate(bombs, transform.position, transform.rotation);
                getBomb=false;
                StartCoroutine(Timer());
            }
        }
        
    }

    //爆弾クールタイム
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeBomb);
        getBomb = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //銃
        if (other.gameObject.tag == "Gun")
        {
            gunKind = 2;
            power+=5;

        }
        //爆弾
        else if (other.gameObject.tag == "Bomb")
        {
            getBomb=true;
        }

        if (other.gameObject.tag == "Cylinder")
        {
            maxO2 = true;
        }

        if (other.gameObject.tag == "Partner")
        {
            onParther = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cylinder")
        {
            maxO2 = false;
            Debug.Log("ok");
        }
    }

    
    public float Speed
    {
        set { this.speed = value; }
        get { return this.speed; }
    }
    public int Direction
    {
        set { this.direction = value; }
        get { return this.direction; }
    }
    public float GunSpeed
    {
        set { this.gunSpeed = value; }
        get { return this.gunSpeed; }
    }
    public int GunKind
    {
        set { this.gunKind = value; }
        get { return this.gunKind; }
    }
    public float TimeGun
    {
        set { this.timeGun = value; }
        get { return this.timeGun; }
    }
    public float HP
    {
        set { this.hp = value; }
        get { return this.hp; }
    }
    public float HPLimit
    {
        set { this.hpLimit = value; }
        get { return this.hpLimit; }
    }
    public float Oxygen
    {
        set { this.oxygen = value; }
        get { return this.oxygen; }
    }
    public bool MaxO2
    {
        set { this.maxO2 = value; }
        get { return this.maxO2; }
    }
    public bool OnParther
    {
        set { this.onParther = value; }
        get { return this.onParther; }
    }
    public float Range
    {
        set { this.range = value; }
        get { return this.range; }
    }
    public bool Rec
    {
        set { this.rec = value; }
        get { return this.rec; }
    }
    public float Power
    {
        set { this.power = value; }
        get { return this.power; }
    }
}
