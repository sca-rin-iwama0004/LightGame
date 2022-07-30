using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Shot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshotR;//UŒ‚(‰E)
    [SerializeField] private GameObject enemyshotL;//UŒ‚(¶)
    [SerializeField] private GameObject enemyshotU;//UŒ‚(ã)
    [SerializeField] private GameObject enemyshotD;//UŒ‚(‰º)
    [SerializeField] private GameObject Shot;//UŒ‚(’ÇÕ)
    GameObject player;
    GameObject enemy4;
    private float span = 5.0f;
    private float span2 = 8.0f;
    private float time = 0f;
    private float time2 = 0f;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //ƒvƒŒƒCƒ„[‚ª”ÍˆÍ“à‚É“ü‚Á‚½‚ç¶¬
        //Debug.Log(arealr);
        if (arealr < 50.0f && arealr > -50.0f)
        {
            if (areaud < 50.0f && areaud > -50.0f)
            {
                float x = enemy4.transform.position.x;
                float y = enemy4.transform.position.y;
                time += Time.deltaTime;
                time2 += Time.deltaTime;
                if (time > span)
                {
                    Instantiate(enemyshotR);
                    Instantiate(enemyshotL);
                    Instantiate(enemyshotU);
                    Instantiate(enemyshotD);
                    enemyshotR.transform.position = new Vector2(x, y);
                    enemyshotL.transform.position = new Vector2(x, y);
                    enemyshotU.transform.position = new Vector2(x, y);
                    enemyshotD.transform.position = new Vector2(x, y);
                    time = 0f;
                }
      
                if (time2 % 10 > span2)
                {
                    Instantiate(Shot);
                    Shot.transform.position = new Vector2(x, y);
                    time2 = 0f;
                }
               

            }
        }


    }


}