using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshot;
    [SerializeField] private GameObject player;
    private float span = 2.0f;
    private float time =0f;
    bool InArea = false;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (InArea == true)
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            time += Time.deltaTime;
            if (time > span)
            {
                Instantiate(enemyshot);
                enemyshot.transform.position = new Vector2(x - 0.7f, y - 0.8f);
                time = 0f;
            }
        }

        arealr = player.transform.position.x - this.transform.position.x;
        //Debug.Log(arealr);
        areaud = player.transform.position.y - this.transform.position.y;
        if (arealr >= 60.0f || arealr <= -60.0f || areaud >= 60.0f || areaud <= -60.0f)//Collider‚ª‚S‚O‚È‚ç60
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
