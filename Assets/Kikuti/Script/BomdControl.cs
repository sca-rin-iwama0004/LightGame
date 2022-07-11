using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BomdControl : MonoBehaviour
{
    //爆弾（攻撃）

    public GameObject Explosion;
    private float time=3.0f;//爆発までの時間

    //効果音
    public GameObject bomdSound;

    // Start is called before the first frame update
    void Start()
    {
       
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //time後に消える
        StartCoroutine(DelayCoroutine(time, () =>
        {
            Instantiate(bomdSound, this.transform.position, this.transform.rotation);//効果音
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);//爆発モーション
            
            
        }));


    }

    //壁を壊す
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
