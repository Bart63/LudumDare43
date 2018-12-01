using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAContainer : MonoBehaviour {

    public RectTransform creationPosition;
    public List<GameObject> container = new List<GameObject>();
    private GameObject temp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        Vector3 pos = new Vector3();
        MakeChildrenGoLeft script = FindObjectOfType<MakeChildrenGoLeft>();

        GameObject random = container[Random.Range(0, container.Count - 1)];

        if (hit.layer == 9)
        {
            pos = creationPosition.position + new Vector3(hit.transform.position.x, 0, 0);
            temp = Instantiate(random, pos, Quaternion.identity, script.gameObject.transform);
            script.AddRB2D(temp.GetComponent<Rigidbody2D>());
        }
    }
}