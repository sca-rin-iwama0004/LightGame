using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGM : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource audioSource;
    private bool Boss = false;//プレイヤーがボスの部屋にいるか

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sounds[0];
        audioSource.Play();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !Boss)
        {
            audioSource.clip = sounds[1];
            audioSource.Play();
            Boss = true;
        }
        else if (other.CompareTag("Player") && Boss)
        {
            audioSource.clip = sounds[0];
            audioSource.Play();
            Boss = false;
        }
    }
}
