using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDecision5Control : MonoBehaviour
{
    //ƒŒƒAŠm—¦•ó” 

    public GameObject Box4;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);


        float rnd = Random.Range(0, 1f);
        if (rnd <= 0.3)
        {
            Instantiate(Box4, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
