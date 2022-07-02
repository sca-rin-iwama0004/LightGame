using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshot;
    [SerializeField] private GameObject player;
    private float span = 2.0f;
    private float time =0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
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
}
