using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildrenGoLeft : MonoBehaviour {

    public float speed = 1f;

    List<RectTransform> childrenTransform = new List<RectTransform>();

	void Start () {
		for(int i=0; i<transform.childCount; i++)
        {
            childrenTransform.Add(transform.GetChild(i).GetComponent<RectTransform>());
        }
	}
	
	void Update () {
        float delta = Time.deltaTime*speed;

        foreach (RectTransform rt in childrenTransform)
        {
            rt.position = new Vector3(rt.position.x-delta, rt.position.y, rt.position.z);
        }
	}
}
