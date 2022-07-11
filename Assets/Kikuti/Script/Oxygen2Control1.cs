using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen2Control1 : MonoBehaviour
{
    //maxé_ëfUI

    private float maxO2 = 500;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = maxO2;
    }
}
