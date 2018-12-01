using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTheContainer : MonoBehaviour {

    MakeChildrenGoLeft script;

    private void Start()
    {
        script = FindObjectOfType<MakeChildrenGoLeft>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.layer == 9 )
        {
            script.RemoveRB2D(hit.GetComponent<Rigidbody2D>());
            Destroy(hit);
        }
    }
}
