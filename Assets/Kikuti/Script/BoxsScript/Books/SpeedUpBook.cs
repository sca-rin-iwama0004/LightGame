using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBook : MonoBehaviour
{
    //移動速度UP

    GameObject player;
    PlayerControl script;

    //効果音
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
            Instantiate(bookSound, this.transform.position, this.transform.rotation);//効果音
            script.Speed += (script.Speed*0.05f);
            script.Ui = "移動速度UP";
            script.UiDecision = true;
            Destroy(gameObject);
        }

    }
}
