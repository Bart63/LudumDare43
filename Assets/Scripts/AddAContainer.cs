using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAContainer : MonoBehaviour {

    public RectTransform creationPosition;
    public GameObject container;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = new GameObject(), hit = collision.gameObject;
        Vector3 pos = new Vector3();
        MakeChildrenGoLeft script = FindObjectOfType<MakeChildrenGoLeft>();

        if (hit.layer == 9)
        {
            pos = creationPosition.position + new Vector3(hit.transform.position.x, 0, 0);
            temp = Instantiate(container, pos, Quaternion.identity, script.gameObject.transform);
            script.AddRB2D(temp.GetComponent<Rigidbody2D>());
        }
    }
}