using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNextBackground : MonoBehaviour
{
    public List<MakeChildrenGoLeftBackground> scripts = new List<MakeChildrenGoLeftBackground>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.layer == 16 || hit.layer == 17 || hit.layer == 18)
        {
            scripts[hit.layer - 16].AddBackground(hit.transform);
            //jakas funkcja w zmiennej script
        }
    }
}