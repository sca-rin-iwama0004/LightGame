using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshot;
    GameObject player;
    private float span = 2.0f;
    private float time =0f;
    bool InArea = false;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //ƒvƒŒƒCƒ„[‚ª”ÍˆÍ“à‚É“ü‚Á‚½‚çenemyshot¶¬
        if (InArea == true)
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            time += Time.deltaTime;
            if (time > span)
            {
                Instantiate(shot);
               shot.transform.position = new Vector2(x - 0.7f, y - 0.8f);
                time = 0f;
            }
        }

        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //Debug.Log(arealr);
        //ƒvƒŒƒCƒ„[‚ª”ÍˆÍŠO‚Éo‚½‚çfalse
        if (arealr >= 80.0f || arealr <= -80.0f || areaud >= 20.0f || areaud <= -20.0f)
        {
            InArea = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //ƒvƒŒƒCƒ„[‚ª“ü‚Á‚½‚çtrue
        if (other.gameObject.tag == "Player")
        {
            InArea = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //ƒvƒŒƒCƒ„[‚ª“ü‚Á‚½‚çtrue
        if (other.gameObject.tag == "Player")
        {
            InArea = true;
        }
    }
}
