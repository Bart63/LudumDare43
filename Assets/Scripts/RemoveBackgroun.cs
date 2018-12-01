using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBackgroun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
       if (hit.layer == 16 || hit.layer == 17 || hit.layer == 18)
        {
            Destroy(hit);
        }
    }
}
