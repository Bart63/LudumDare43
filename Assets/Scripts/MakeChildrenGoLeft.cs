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
        speed += Time.deltaTime;
        float delta = Time.deltaTime*speed;

        foreach (Rigidbody2D rb in childrenTransform)
        {
            rb.velocity = new Vector2(-1 * delta, 0);
        }
	}

    public void AddRB2D(Rigidbody2D rb)
    {
        childrenTransform.Add(rb);
    }

    public void RemoveRB2D(Rigidbody2D rb)
    {
        childrenTransform.Remove(rb);
    }
}
