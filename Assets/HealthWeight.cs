using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWeight : MonoBehaviour {
    public int MaxHealth;
    public int MaxFood;
    public int CurrentHealth;
    public int CurrentFood;

    public GameObject HPBar;
    public GameObject FoodBar;

    HeightOfBaloon script;

    private void Start()
    {
        script = FindObjectOfType<HeightOfBaloon>();
        

    }

    void Update()
    {

        HPBar.transform.localScale = new Vector3 ((float)CurrentHealth / (float)MaxHealth, 1, 0);
        FoodBar.transform.localScale = new Vector3((float)CurrentFood / (float)MaxFood, 1, 0);


        if (Input.GetMouseButtonDown(1) && script.currentFood>0 && CurrentHealth<100)
        {
            CurrentHealth += 1;
            script.currentFood -= 1;
            FindObjectOfType<GetFatter>().GetMoreFat();
        }

        if (CurrentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("DestroyBallon");
        }

        if (CurrentFood <= 0)
        {
            CurrentHealth = 0;
        }
    }

 private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;

        if (hit.layer == 13)
        {
            FindObjectOfType<AudioManager>().Play("kruk2");

            Destroy(hit);
            CurrentHealth -= 3;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
            }
            
        }


    }
}
