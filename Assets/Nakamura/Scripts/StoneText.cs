using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneText : MonoBehaviour
{
    [SerializeField] private Text stoneText;

    // Start is called before the first frame update
    void Start()
    {
        stoneText.text = Player.asset.ToString();
        Debug.Log(Player.item);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
