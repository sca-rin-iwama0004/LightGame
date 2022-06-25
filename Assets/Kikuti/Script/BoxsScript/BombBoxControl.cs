using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoxControl : MonoBehaviour
{
    //爆弾確定宝箱

    public GameObject bomb;

    //開く効果音
    public GameObject openSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(openSound, this.transform.position, this.transform.rotation);//効果音
            Destroy(gameObject);

            Instantiate(bomb, this.transform.position, this.transform.rotation);
            //ジャンプUP

        }

    }
}
