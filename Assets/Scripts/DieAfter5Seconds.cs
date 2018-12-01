using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfter5Seconds : MonoBehaviour {

    public float time = 5f;

	void Update () {
        time -= Time.deltaTime;
        if (time<=0)
        {
            Destroy(gameObject);
        }
	}
}
