using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;

        if (hit.layer == 13)
        {
            FindObjectOfType<AudioManager>().Play("kruk2");

            Destroy(hit);
            Destroy(gameObject);

        }
    }
}
