using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EffectControl : MonoBehaviour
{
    //モーション

    // Start is called before the first frame update
    void Start()
    {
        //2秒後に消える
        StartCoroutine(DelayCoroutine(2, () =>
        {
            Destroy(gameObject);


        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
