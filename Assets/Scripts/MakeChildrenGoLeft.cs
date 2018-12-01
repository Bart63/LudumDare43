using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildrenGoLeft : MonoBehaviour {

    public float speed = 1f;

    List<Rigidbody2D> childrenTransform = new List<Rigidbody2D>();

	void Start () {
		for(int i=0; i<transform.childCount; i++)
        {
            childrenTransform.Add(transform.GetChild(i).GetComponent<Rigidbody2D>());
        }
	}
	
	void Update () {
        float delta = Time.deltaTime*speed;

        foreach (Rigidbody2D rb in childrenTransform)
        {
            rb.AddForce(new Vector2(-1 * delta, 0));
        }
	}
}
