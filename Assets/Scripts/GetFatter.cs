using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFatter : MonoBehaviour {

    public float slim, fat;
    public int steps;
    private Vector3 scale;
    private int currentStep = 0;
	void Start () {
        scale = GetComponent<RectTransform>().localScale;
        GetComponent<RectTransform>().localScale = new Vector3(slim, scale.y,scale.z);	
	}

    public void GetMoreFat()
    {
        if (currentStep < steps)
        {
            currentStep++;
            GetComponent<RectTransform>().localScale = new Vector3( (slim*(steps-currentStep)+fat*currentStep)/steps, scale.y, scale.z);
            FindObjectOfType<HeightOfBaloon>().Weight += 2;
        }
    }
	
}
