using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainScript : MonoBehaviour
{
    public GameObject[] Train;
    

    void Start()
    {
    
       int  number = Random.Range(0, Train.Length);
        // Instantiate(Train[number], transform.position, transform.rotation);
        Instantiate(Train[number], new Vector3(1f,0f,0.0f),Quaternion.identity);


    }
       
    }
        
