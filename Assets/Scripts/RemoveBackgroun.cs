using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBackgroun : MonoBehaviour
{
    public List<MakeChildrenGoLeftBackground> scripts = new List<MakeChildrenGoLeftBackground>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
       if (hit.layer == 16 || hit.layer == 17 || hit.layer == 18)
        {
            scripts[hit.layer - 16].childrenTransform.Remove(collision.GetComponent<Rigidbody2D>());
            Destroy(hit);
        }
    }
}
