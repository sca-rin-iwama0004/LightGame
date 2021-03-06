using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEnd : MonoBehaviour
{
    //効果音消す

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //三秒後に効果音を消す
        StartCoroutine(DelayCoroutine(3, () =>
        {
            Destroy(gameObject);


        }));
    }
    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

}
