using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy01 : MonoBehaviour
{
    PlayerControl script;
    private float hp = 200.0f;
    private float nowhp;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Food;
    [SerializeField] private GameObject Bronze;
    [SerializeField] private GameObject player;
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    { 
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 100;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int coin = 0;
        int c = 0;
        int food = 0;
        int bronze = 0;
        int b =0;
        if (other.gameObject.tag == "Bullet")
        {
            hp -= script.Power;
            hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Gun")
        {
          hp -= (script.Power / 2);
          hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Explosion")
        {
          hp -= 50;
          hpSlider.value = hp;
        }

        if (hp <= 0)
        {
            coin = Random.Range(0, 2);
            food = Random.Range(0, 2);
            bronze = Random.Range(0,2);
            if (coin == 1)
            {
                while (c < 10)
                {
                    Instantiate(Coin);
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Coin.transform.position = new Vector2(x, this.transform.position.y);
                    c++;
                }

            }

            if (food == 1)
            {
                float x = Random.Range(this.transform.position.x + 1, this.transform.position.x - 1);
                Instantiate(Food);
                Food.transform.position = new Vector2(x, this.transform.position.y);
            }

            if(bronze  == 1)
            {
                while(b< 1)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Bronze);
                    Bronze.transform.position = new Vector2(x, this.transform.position.y);
                    b++;
                }
                
            }
            this.gameObject.SetActive(false);
        }
    }
}