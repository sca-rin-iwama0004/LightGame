using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour
{
    GameObject enemy5;
    private bool a;
    // Start is called before the first frame update
    void Start()
    {
        enemy5 = GameObject.Find("Enemy5");
        float x = enemy5.transform.position.x - 12.6f;
        float y = enemy5.transform.position.y + 4.05f;
        this.transform.position =new Vector3(x,y);
    }

    // Update is called once per frame
    void Update()
    {
        a= enemy5.activeSelf;
        //enemy5‚ªfalse‚É‚È‚Á‚½‚çfalse‚É‚·‚é
        if(a == false)
        {
            this.gameObject.SetActive(false);
        }
    }
}
