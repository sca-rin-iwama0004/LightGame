using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ComentUi : MonoBehaviour
{
    //アイテム獲得テキスト表示
    public Text text;

    GameObject player;
    PlayerControl script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (script.UiDecision2 == true)//表示
        {
            text.text = script.Ui2;
            StartCoroutine(DelayCoroutine(5, () => //１秒後非表示
            {
                text.text = " ";
            }));
            script.UiDecision2 = false;

        }
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
