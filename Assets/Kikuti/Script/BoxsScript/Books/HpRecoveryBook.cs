using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRecoveryBook : MonoBehaviour
{
    //HP自動回復

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
            script.Rec=true;
            script.Ui = "HP自動回復GET";
            script.UiDecision = true;
            Destroy(gameObject);
        }

    }
}
