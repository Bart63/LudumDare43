using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWeight : MonoBehaviour {
    public int MaxHealth;
    private int MaxFood;
    public int MaxFull;

    public int CurrentHealth;
    private int CurrentFood;
    public int CurrentFull;

    public Text Life;
    public Text Food;
    public Text Full;

    public GameObject HPBar;
    public GameObject FoodBar;
    public GameObject FullBar;

    private float width;

    HeightOfBaloon script;

    private void Start()
    {
        MaxFood = transform.parent.GetComponent<HeightOfBaloon>().maxFood;
        CurrentFood = transform.parent.GetComponent<HeightOfBaloon>().currentFood;

        script = FindObjectOfType<HeightOfBaloon>();
        width = Life.GetComponent<RectTransform>().rect.width;
        Life.text = "Life: " + CurrentHealth.ToString();
        Food.text = "Food: " + CurrentFood.ToString();

    }

    void Update()
    {
        MaxFood = transform.parent.GetComponent<HeightOfBaloon>().maxFood;
        CurrentFood = transform.parent.GetComponent<HeightOfBaloon>().currentFood;
        if (HPBar != null && FoodBar != null && FullBar != null)
        {
            HPBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentHealth / (float)MaxHealth* width, HPBar.GetComponent<RectTransform>().sizeDelta.y);
            FoodBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentFood / (float)MaxFood * width, FoodBar.GetComponent<RectTransform>().sizeDelta.y);
            FullBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentFull / (float)MaxFull * width, FoodBar.GetComponent<RectTransform>().sizeDelta.y);
        }

        if (Input.GetMouseButtonDown(1) && script.currentFood>0 && CurrentHealth<100)
        {
            transform.parent.GetComponent<HeightOfBaloon>().currentFood--;
            CurrentHealth += 1;
            FindObjectOfType<GetFatter>().GetMoreFat();
        }

        Life.text = "Life: " + CurrentHealth.ToString();
        Food.text = "Food: " + CurrentFood.ToString();

        if (Input.GetMouseButtonDown(1) && script.currentFood > 0 && CurrentHealth <= 100)
        {
            CurrentFull += CurrentFull;
            Full.text = "Being full: " + CurrentFull.ToString();
        }

        Life.text = "Life: " + CurrentHealth.ToString();
        Food.text = "Food: " + CurrentFood.ToString();

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
