﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealth : MonoBehaviour
{

    HealthWeight hw;

    private void Start()
    {
        hw = FindObjectOfType<HealthWeight>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 22)
        {
            hw.CurrentHealth += 10;
        }
    }
}
