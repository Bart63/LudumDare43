using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightOfBaloon : MonoBehaviour {

    public Transform maxHeight, minHeight;
    public int maxFood, currentFood;
    private float ymax, ymin;
    void Start () {
	}
	

	void Update () {
        ymax = maxHeight.position.y;
        ymin = minHeight.position.y;

        float currentDestination = (currentFood * ymin + (maxFood - currentFood) * ymax) / maxFood;
        float deltaPosition = currentDestination - transform.position.y;
        
        transform.position = new Vector3(transform.position.x, transform.position.y+deltaPosition*Time.deltaTime, transform.position.z);
    }
}
