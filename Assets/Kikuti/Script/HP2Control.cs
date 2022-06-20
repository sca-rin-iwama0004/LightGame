using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP2Control : MonoBehaviour
{

    private Image image;

    GameObject player;
    PlayerControl script;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();

        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

        image.fillAmount = script.HPLimit / 500.0f;
    }
}
