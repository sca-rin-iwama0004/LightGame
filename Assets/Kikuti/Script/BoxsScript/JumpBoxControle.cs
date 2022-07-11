using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoxControle : MonoBehaviour
{
    //ジャンプUP確定宝箱

    public GameObject jumpUpBook;

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

            Instantiate(jumpUpBook, this.transform.position, this.transform.rotation);//ジャンプUP
            
        }

    }
}
