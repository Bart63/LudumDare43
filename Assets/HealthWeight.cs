using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWeight : MonoBehaviour {
    public int MaxHealth;
    public int CurrentHealth;
    HeightOfBaloon script;

    private void Start()
    {
        script = FindObjectOfType<HeightOfBaloon>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && script.currentFood>0 && CurrentHealth<100)
        {
            CurrentHealth += 1;
            script.currentFood -= 1;
        }
    }

 private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;

        if (hit.layer == 13)
        {
            Destroy(hit);
            CurrentHealth -= 3;
        }
    }
}
