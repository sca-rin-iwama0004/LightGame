using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    //効果音
    public GameObject gunSound;

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
        //プレイヤーに取得され消える
        if (other.gameObject.tag == "Player")
        {
            Instantiate(gunSound, this.transform.position, this.transform.rotation);//効果音
            Destroy(gameObject);
        }

    }


}
