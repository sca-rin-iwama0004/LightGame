using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    public Slider slider;
    public GameObject ClearText;//一応

    private Rigidbody2D rigidBody;//★


    void Start()
    {
        slider.value = 100;
      
        // ClearText.SetActive(false);
    }

    void EndingGame()
    {
        //3秒後にメソッドを実行する
        Invoke("LoadEndingScene", 3);
    }

    void LoadEndingScene()
    {
        SceneManager.LoadScene("GamaOver");//ゲームオーバーの画面
    }

   
}


