using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ƒ{ƒ^ƒ“‚ð‰Ÿ‚µ‚½‚çTitle‚ÖˆÚ“®‚·‚é
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
            
    }
}

