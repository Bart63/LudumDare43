using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightOfBaloon : MonoBehaviour {

    public Transform maxHeight, minHeight;
    public int maxFood, currentFood;
    public int maxWeight, Weight;
    private float ymax, ymin;
    public float speed;
    void Start ()
    {
        ymax = maxHeight.position.y;
        ymin = minHeight.position.y;

        float currentDestination = (Weight * ymin + (maxWeight - Weight) * ymax) / maxWeight;

        transform.position = new Vector3(transform.position.x, currentDestination, transform.position.z);
    }
	

	void Update () {
        ymax = maxHeight.position.y;
        ymin = minHeight.position.y;

        float currentDestination = (Weight * ymin + (maxWeight - Weight) * ymax) / maxWeight;
        float deltaPosition = currentDestination - transform.position.y;

        if (Mathf.Abs(deltaPosition) > .01f)
        {
            //GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(new Vector2(0,transform.position.y), new Vector2(0, currentDestination), Time.deltaTime);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, deltaPosition*Time.deltaTime*speed);
        }

        //the same thing but on transform
        transform.position = new Vector3(transform.position.x, transform.position.y+deltaPosition*Time.deltaTime, transform.position.z);
    }
}
