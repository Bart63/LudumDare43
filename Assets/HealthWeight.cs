using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private float deltaTime = 1f;
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
        CurrentFull += 1;
        InvokeRepeating("DecremantationOfFood", 0f, 1f);
    }

    void DecremantationOfFood()
    {
        if (CurrentFull <= 0)
        {
            CurrentHealth -=5;
            if(CurrentHealth<0)
            {
                CurrentHealth = 0;
            }
        }
        else
        {
            CurrentFull--;
        }
        //StartCoroutine("DecremantationOfFood", 1f);
    }

    void Update()
    {
        if (CurrentFood <= 0)
        {
            Debug.Log("0 food");
            deltaTime -= Time.deltaTime;
            if (deltaTime <= 0)
            {
                CurrentFull -= 8;
                deltaTime = 1f;
            }
        }
        MaxFood = transform.parent.GetComponent<HeightOfBaloon>().maxFood;
        CurrentFood = transform.parent.GetComponent<HeightOfBaloon>().currentFood;
        if (HPBar != null && FoodBar != null && FullBar != null)
        {
            HPBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentHealth / (float)MaxHealth* width, HPBar.GetComponent<RectTransform>().sizeDelta.y);
            FoodBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentFood / (float)MaxFood * width, FoodBar.GetComponent<RectTransform>().sizeDelta.y);
            FullBar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)CurrentFull / (float)MaxFull * width, FoodBar.GetComponent<RectTransform>().sizeDelta.y);
        }

        if (Input.GetMouseButtonDown(1) && script.currentFood > 0 && CurrentHealth <= 100)
        {
            FindObjectOfType<GetFatter>().GetMoreFat(CurrentFull);

            CurrentFull += 10;
            transform.parent.GetComponent<HeightOfBaloon>().currentFood--;
            
        }

        Full.text = "Fullness: " + CurrentFull.ToString();
        Life.text = "Life: " + CurrentHealth.ToString();
        Food.text = "Food: " + CurrentFood.ToString();

        if (CurrentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("DestroyBallon");
        }
    }

 private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;

        if (hit.layer == 13)
        {
            FindObjectOfType<AudioManager>().Play("kruk2");

            Destroy(hit);
            CurrentHealth -= 10;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            

            Life.text = "Life: " + CurrentHealth.ToString();

        }


    }
}
