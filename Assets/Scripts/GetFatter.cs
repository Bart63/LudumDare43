using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFatter : MonoBehaviour {

    public float slim, fat;
    public int steps;
    private Vector3 scale;
    private int currentStep = 0;
    int prev, curr;
    void Start () {
        scale = GetComponent<RectTransform>().localScale;
        GetComponent<RectTransform>().localScale = new Vector3(slim, scale.y,scale.z);
        prev = Mathf.FloorToInt(FindObjectOfType<HealthWeight>().CurrentFull/10);
    }


    private void Update()
    {
        int numb = FindObjectOfType<HealthWeight>().CurrentFull;
        GetComponent<RectTransform>().localScale = new Vector3((slim * (100 - numb) + fat * numb) / 100, scale.y, scale.z);

        curr = Mathf.FloorToInt(FindObjectOfType<HealthWeight>().CurrentFull/10);
        if(curr <= prev-1)
        {
            FindObjectOfType<HeightOfBaloon>().Weight -= 3;
            prev = curr;
            Debug.Log("Go up");
        }
    }

    public void GetMoreFat(int prevfull)
    {
        prev = Mathf.FloorToInt(FindObjectOfType<HealthWeight>().CurrentFull / 10);
        FindObjectOfType<HeightOfBaloon>().Weight += 3;
    }
	
}
