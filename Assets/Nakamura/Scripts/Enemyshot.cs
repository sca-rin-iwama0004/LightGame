using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshot;
    private GameObject enemy1;
    private float span = 2.0f;
    private float time =0f;
   
    // Start is called before the first frame update
    void Start()
    {
       
        enemy1 = GameObject.Find("Enemy1");
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
         float x = enemy1.transform.position.x;
         float y = enemy1.transform.position.y;
        if (time >span)
        {
            Instantiate(enemyshot);
            enemyshot.transform.position = new Vector2(x-0.7f, y-0.8f);
            time =0f;
        }
    }

   

}
