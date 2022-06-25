using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRange3Control : MonoBehaviour
{
    //x
    GameObject player;
    PlayerControl script;

    BoxCollider2D boxCol;
    private float range;
    private float posX, posY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

        boxCol = GetComponent<BoxCollider2D>();
        posX = boxCol.size.x;
        posY = boxCol.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        boxCol.size = new Vector3(script.JumpPower, posY, script.JumpPower);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            script.JumpDecision3 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            script.JumpDecision3 = false;
        }
    }
}
