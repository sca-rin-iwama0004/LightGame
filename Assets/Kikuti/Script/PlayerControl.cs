using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //プレイヤー

    //画像
    [SerializeField] private Sprite playerPrevious;
    [SerializeField] private Sprite playerBehind;
    [SerializeField] private Sprite playerSide;

    private SpriteRenderer renderer;
    SpriteRenderer sr;

    //移動
    private float speed=0.05f; //移動速度
    private Rigidbody2D rb;
    private float jumpPower=1;//ジャンプ力
    //ジャンプ判定
    private bool jumpDecision = false;
    private bool jumpDecision2 = false;
    private bool jumpDecision3 = false;
    private bool jumpDecision4 = false;
    private bool jumpHole = false;
    private bool jumpHole2 = false;
    private bool jumpHole3 = false;
    private bool jumpHole4 = false;
    public GameObject jumpSound;

    //プレイヤーの向いてる方向
    public enum PlayerDirection
    {
        UP,
        LEFT,
        RIGHT,
        DOWN
    }
    private PlayerDirection direction;

    //弾
    public enum PlayerWeapon
    {
        KNIF,
        GUN
    }
    private PlayerWeapon weapon;
    public GameObject knife;
    public GameObject gun;
    private float timeGun=3.0f;  //攻撃を撃つ速度
    private float gunSpeed = 30;//攻撃が飛ぶ速度
    private float range=0; //増加攻撃範囲
    private float power=50; //攻撃力

    //防御力
    private float defense = 0;//%

    //爆弾
    bool getBomb=false;
    public GameObject bombs;
    private float timeBomb=30;//爆弾設置クールタイム                     

    private float timeElapsed;

    //HP酸素
    private float hp=100.0f;
    private float hpLimit = 100.0f;  //その時のmaxのHP
    private float oxygen=150.0f;
    private float oxygenMax = 150.0f;
    private bool placeO2=false;  //酸素ボンベ
    private bool rec=false;    //HP自動回復

    private bool onParther = false;//追従開始
    private int parCount=0;  //仲間判定

    //ショップ画面
    public static int coin = 0;
    public static int asset = 0;     //資源
    public static bool shopResu=false; //ショップ蘇生
    public static bool shopRange=false;//ショップ攻撃範囲
    public static bool shopDefense = false;//ショップ防御力
    public static bool shopRec = false;//ショップ自動回復

    //UI
    private string ui;
    private bool uiDecision=false;

    

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();

        renderer = GetComponent<SpriteRenderer>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        direction = PlayerDirection.LEFT;
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        if (horizontalKey > 0)//右
        {
            rb.position += new Vector2(speed,0 );
            sr.sprite = playerSide;
            renderer.flipX = true;
            direction = PlayerDirection.RIGHT;
        }
        else if (horizontalKey < 0)//左
        {
            rb.position += new Vector2(-speed, 0);
            sr.sprite = playerSide;
            renderer.flipX = false;
            direction = PlayerDirection.LEFT;
        }

        if (verticalKey > 0)//上
        {
            rb.position += new Vector2(0,speed);
            sr.sprite = playerBehind;
            direction = PlayerDirection.UP;
        }
        else if (verticalKey < 0)//下
        {
            rb.position += new Vector2(0, -speed);
            sr.sprite = playerPrevious;
            direction = PlayerDirection.DOWN;
        }

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.C))
        {
            float tile = 5;//１タイルの幅

            //右にジャンプ（向いてる方向に床があるか&&向いてる方向に穴があるか）
            if (jumpDecision == true && jumpHole == true)
            {
                if (direction == PlayerDirection.RIGHT)
                {
                    this.transform.position = new Vector2(this.transform.position.x + (tile * (jumpPower + 2)), this.transform.position.y);
                    Instantiate(jumpSound, this.transform.position, this.transform.rotation);

                }
            }
            //左にジャンプ（向いてる方向に床があるか&&向いてる方向に穴があるか）
            if (jumpDecision3 == true && jumpHole3 == true)
            {
                if (direction == PlayerDirection.LEFT)
                {
                    this.transform.position = new Vector2(this.transform.position.x - (tile * (jumpPower + 2)), this.transform.position.y);
                    Instantiate(jumpSound, this.transform.position, this.transform.rotation);
                }

            }
            //上にジャンプ（向いてる方向に床があるか&&向いてる方向に穴があるか）
            if (jumpDecision4 == true && jumpHole4 == true)
            {
                if (direction == PlayerDirection.UP)
                {
                    this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + (tile * (jumpPower + 2)));
                    Instantiate(jumpSound, this.transform.position, this.transform.rotation);
                }
            }
            //下にジャンプ（向いてる方向に床があるか&&向いてる方向に穴があるか）
            if (jumpDecision2 == true && jumpHole2 == true)
            {
                if (direction == PlayerDirection.DOWN)
                {
                    this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - (tile * (jumpPower + 2)));
                    Instantiate(jumpSound, this.transform.position, this.transform.rotation);
                }
            }
        }

        //弾
        timeElapsed += Time.deltaTime;

        //
        if (timeElapsed >= timeGun)
        {
            if (weapon == PlayerWeapon.KNIF)//ナイフ
            {
                Instantiate(knife, transform.position, transform.rotation);
            }
            else if (weapon == PlayerWeapon.GUN)//銃
            {
                Instantiate(gun, transform.position, transform.rotation);
            }
           
            timeElapsed = 0.0f;
        }

        //爆弾設置
        if(Input.GetKeyDown(KeyCode.Space)){
            if (getBomb == true) {
                Instantiate(bombs, transform.position, transform.rotation);
                getBomb=false;
                //クールタイム
                StartCoroutine(Timer());
            }
        }

        //ゲームオーバー
        if (hp <= 0||oxygen<=0)
        {
            //蘇生実行
            if(shopResu==true)
            { 
                hpLimit=hp;
                shopResu=false;
            } 
            //ゲームオーバー
            else
            {
                asset = 0;
                SceneManager.LoadScene("GameOver");
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
        if (other.gameObject.tag == "Guns")
        {
            weapon=PlayerWeapon.GUN;//武器を銃に変更
            power+=5;
            ui="銃GET";
            uiDecision=true;
        }

        //爆弾
        else if (other.gameObject.tag == "Bomb")
        {
            getBomb=true;
            ui = "爆弾GET";
            uiDecision = true;
        }

        //酸素回復エリア入り
        if (other.gameObject.tag == "Cylinder")
        {
            placeO2 = true;
        }

        //仲間追従開始
        if (other.gameObject.tag == "Partner")
        {
            onParther = true;
            if (parCount == 0) {
                ui = "仲間GET";
                uiDecision = true;
            }
            parCount=1;
            
        }

        //酸素回復攻撃に当たったら１０回復
        if (other.gameObject.tag == "O2")
        {
            oxygen +=10;
        }

        
        //敵キャラ攻撃受ける
        //ざこ1
        if (other.gameObject.tag == "Enemy1")
        {
            hp -= (10 - (10 * (defense / 100)));
        }
        /*
        //ざこ2
        if (other.gameObject.tag == "Enemy2")
        {
            hp -= (15 - (15 * (defense / 100)));
        }
        //ざこ３即死
        if (other.gameObject.tag == "DieEnemy")
        {
            hp = 0;
        }
        */
        
        //中ボス1,2
        if (other.gameObject.tag == "Enemy4" || other.gameObject.tag == "Enemy5")
        {
            hp -= (20 - (20 * (defense / 100)));
        }
        //ボス
        if (other.gameObject.tag == "Boss")
        {
            hp -= (30 - (30 * (defense / 100)));
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cylinder")
        {
            placeO2 = false;
        }//酸素回復エリア抜け出し
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //コインゲット
        if (other.gameObject.tag == "Coin")
        {
            coin += 1;
            ui = "コインGET";
            uiDecision = true;
        }

        //資源ゲット
        if (other.gameObject.tag == "Stone")
        {
            asset += 1;
            ui = "資源GET";
            uiDecision = true;
        }

        //敵キャラ攻撃受ける
        //ざこ1
        if (other.gameObject.tag == "Enemy1")
        {
            hp -= (10 - (10 * (defense / 100)));
        }
        //ざこ2
        if (other.gameObject.tag == "Enemy2")
        {
            hp -= (15 - (15 * (defense / 100)));
        }
        //ざこ３即死
        if (other.gameObject.tag == "DieEnemy")
        {
            hp = 0;
        }
        //中ボス1,2
        if (other.gameObject.tag == "Enemy4" || other.gameObject.tag == "Enemy5")
        {
            hp -= (20 - (20 * (defense / 100)));
        }
        //ボス
        if (other.gameObject.tag == "Boss")
        {
            hp -= (30 - (30 * (defense / 100)));
        }



    }

    



    public float Speed
    {
        set { this.speed = value; }
        get { return this.speed; }
    }
    public PlayerDirection Direction
    {
        set { this.direction = value; }
        get { return this.direction; }
    }
    public float GunSpeed
    {
        set { this.gunSpeed = value; }
        get { return this.gunSpeed; }
    }
    public PlayerWeapon Weapon    
    {
        set { this.weapon = value; }
        get { return this.weapon; }
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
    public float OxygenMax
    {
        set { this.oxygenMax = value; }
        get { return this.oxygenMax; }
    }
    public bool PlaceO2
    {
        set { this.placeO2 = value; }
        get { return this.placeO2; }
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
    public float JumpPower
    {
        set { this.jumpPower = value; }
        get { return this.jumpPower; }
    }
    public bool JumpDecision
    {
        set { this.jumpDecision = value; }
        get { return this.jumpDecision; }
    }
    public bool JumpDecision2
    {
        set { this.jumpDecision2 = value; }
        get { return this.jumpDecision2; }
    }
    public bool JumpDecision3
    {
        set { this.jumpDecision3 = value; }
        get { return this.jumpDecision3; }
    }
    public bool JumpDecision4
    {
        set { this.jumpDecision4 = value; }
        get { return this.jumpDecision4; }
    }
    public float Defense
    {
        set { this.defense = value; }
        get { return this.defense; }
    }
    public bool JumpHole
    {
        set { this.jumpHole = value; }
        get { return this.jumpHole; }
    }
    public bool JumpHole2
    {
        set { this.jumpHole2 = value; }
        get { return this.jumpHole2; }
    }
    public bool JumpHole3
    {
        set { this.jumpHole3 = value; }
        get { return this.jumpHole3; }
    }
    public bool JumpHole4
    {
        set { this.jumpHole4 = value; }
        get { return this.jumpHole4; }
    }
    public string Ui
    {
        set { this.ui = value; }
        get { return this.ui; }
    }
    public bool UiDecision
    {
        set { this.uiDecision = value; }
        get { return this.uiDecision; }
    }

}
