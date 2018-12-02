using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFatter : MonoBehaviour {

    public float slim, fat;
    public int steps;
    private Vector3 scale;
    private int currentStep = 0;
    private float prev, curr;
	void Start () {
        scale = GetComponent<RectTransform>().localScale;
        GetComponent<RectTransform>().localScale = new Vector3(slim, scale.y,scale.z);	
	}


    private void Update()
    {
        int numb = FindObjectOfType<HealthWeight>().CurrentFull;
        GetComponent<RectTransform>().localScale = new Vector3((slim * (100 - numb) + fat * numb) / 100, scale.y, scale.z);
    }

    public void GetMoreFat()
    {
        FindObjectOfType<HeightOfBaloon>().Weight += 2;
    }
	
}
