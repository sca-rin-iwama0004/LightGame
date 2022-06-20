using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDecision2Control : MonoBehaviour
{
    //ämó¶í èÌïÛî†

    public GameObject Box1;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().color=new Color(0,0,0,0);
        

        float rnd = Random.Range(0, 1f);
        if (rnd <= 0.5)
        {
            Instantiate(Box1, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
