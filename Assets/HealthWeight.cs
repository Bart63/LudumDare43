using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWeight : MonoBehaviour {
    public int MaxHealth;
    public int MaxFood;
    public int CurrentHealth;
    public int CurrentFood;

    public Text Life;
    public Text Food;

    public GameObject HPBar;
    public GameObject FoodBar;

    private float width;

    HeightOfBaloon script;

    private void Start()
    {
        script = FindObjectOfType<HeightOfBaloon>();
        width = Life.GetComponent<RectTransform>().rect.width;
        Life.text = "Life: " + CurrentHealth.ToString();
        Food.text = "Food: " + CurrentFood.ToString();

    }

    void Update()
    {

        if (HPBar != null && FoodBar != null)
        {
            HPBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentHealth / (float)MaxHealth* width, HPBar.GetComponent<RectTransform>().sizeDelta.y);
            FoodBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentFood / (float)MaxFood * width, FoodBar.GetComponent<RectTransform>().sizeDelta.y);
        }

        if (Input.GetMouseButtonDown(1) && script.currentFood>0 && CurrentHealth<100)
        {
            CurrentHealth += 1;
            script.currentFood -= 1;
            FindObjectOfType<GetFatter>().GetMoreFat();
            Life.text = "Life: " + CurrentHealth.ToString();
            Food.text = "Food: " + CurrentFood.ToString();
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
                Life.text = "Life: " + CurrentHealth.ToString();
            }

            Life.text = "Life: " + CurrentHealth.ToString();

        }


    }
}
