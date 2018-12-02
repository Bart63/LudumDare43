﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFood : MonoBehaviour {

    HeightOfBaloon hob;

    private void Start()
    {
        hob = FindObjectOfType<HeightOfBaloon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==14)
        {
            hob.currentFood += 3;
            hob.Weight += 3;
            Destroy(collision.gameObject);
            if(gameObject.layer==19)
            {
                Destroy(gameObject);
            }
        }
    }
}