using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUpBook : MonoBehaviour
{
    //HPUP

    GameObject player;
    PlayerControl script;

    //Œø‰Ê‰¹
    public GameObject bookSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(bookSound, this.transform.position, this.transform.rotation);//Œø‰Ê‰¹
            script.HPLimit += 10.0f;
            script.HP = script.HPLimit;
            Destroy(gameObject);
        }

    }
}
