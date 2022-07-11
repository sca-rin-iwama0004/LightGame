using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Shot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshotR;
    [SerializeField] private GameObject enemyshotL;
    [SerializeField] private GameObject enemyshotU;
    [SerializeField] private GameObject enemyshotD;
    [SerializeField] private GameObject player;
    GameObject enemy4;
    private float span = 5.0f;
    private float time = 0f;
    bool InArea = false;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");

    }

    // Update is called once per frame
    void Update()
    {
        if (InArea == true)
        {
            float x = enemy4.transform.position.x;
            float y = enemy4.transform.position.y;
            time += Time.deltaTime;
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

        }

        arealr = player.transform.position.x - this.transform.position.x;
        //Debug.Log(arealr);
        areaud = player.transform.position.y - this.transform.position.y;
        if (arealr >= 60.0f || arealr <= -60.0f || areaud >= 60.0f || areaud <= -60.0f)
        {
            InArea = false;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        InArea = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        InArea = true;
    }

}