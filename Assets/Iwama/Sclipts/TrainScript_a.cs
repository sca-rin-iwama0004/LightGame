using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript_a : MonoBehaviour
{
    [SerializeField] protected GameObject[] Train;
    protected int randomNumber;
    protected int a;
    protected int number;

    protected virtual void Start()
    {
        number = Random.Range(0, Train.Length);
        Instantiate(Train[number], transform.position, transform.rotation);
    }
    

    public int GetNumberA()
    {
        if (number == 0)
        {
            a = 0;
            Debug.Log("a=" + a);
        }
        else if (number == 1)
        {
            a = 1;
            Debug.Log("a=" + a);
        }
        else if (number == 2)
        {
            a = 2;
            Debug.Log("a=" + a);
        }
        else if (number == 3)
        {
            a = 3;
            Debug.Log("a=" + a);
        }
        else if (number == 4)
        {
            a = 4;
            Debug.Log("a=" + a);
        }
        else if (number == 5)
        {
            a = 5;
            Debug.Log("a=" + a);
        }
        else if (number == 6)
        {
            a = 6;
            Debug.Log("a=" + a);
        }
        else if (number == 7)
        {
            a = 7;
            Debug.Log("a=" + a);
        }
        else if (number == 8)
        {
            a = 8;
            Debug.Log("a=" + a);
        }
        else if (number == 9)
        {
            a = 9;
            Debug.Log("a=" + a);
        }

        return a;

    }
}
        
