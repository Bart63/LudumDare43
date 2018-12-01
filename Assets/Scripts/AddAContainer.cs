using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAContainer : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Weszlo");
        Debug.Log(collision.gameObject.layer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Weszlo");
        Debug.Log(collision.gameObject.layer);
    }
}