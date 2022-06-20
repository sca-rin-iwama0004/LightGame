using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2UpBook : MonoBehaviour
{
    //O2‘Ï‹vUP

    GameObject oxygen;
    OxygenControl script;

    // Start is called before the first frame update
    void Start()
    {
        oxygen = GameObject.Find("Oxygen");
        script = oxygen.GetComponent<OxygenControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.O2Up += 1.0f;
            Destroy(gameObject);
        }

    }
}
