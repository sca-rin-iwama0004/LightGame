using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class UIManager : MonoBehaviour
{
    //３つのPanelを格納する変数
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        //BackToMenuメソッドを呼び出す
     //   BackToMenu();
    }

    
    void OnCollisionEnter2D(Collision2D Collision)
    {
      
            Panel.SetActive(true);
      
    }

}