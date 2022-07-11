using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    //Œø‰Ê‰¹
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
        //ƒvƒŒƒCƒ„[‚Éæ“¾‚³‚êÁ‚¦‚é
        if (other.gameObject.tag == "Player")
        {
            Instantiate(gunSound, this.transform.position, this.transform.rotation);//Œø‰Ê‰¹
            Destroy(gameObject);
        }

    }


}
