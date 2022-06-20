using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BomdControl : MonoBehaviour
{
    public GameObject Explosion;
    private float time=3.0f;//”š”­‚Ü‚Å‚ÌŽžŠÔ
    private bool door=false;
    
    // Start is called before the first frame update
    void Start()
    {
       
       
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(DelayCoroutine(time, () =>
        {
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);
            
            
        }));


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            Destroy(other.gameObject, time);
        }
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

   


}
