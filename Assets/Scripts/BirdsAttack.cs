using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsAttack : MonoBehaviour {
    List<GameObject> children = new List<GameObject>();
    float time = 0f, maxTime=15f;
    GameObject birdAttack;
    bool go = false;
    public float velocity = 100f, acc = 2f;
    private void Start()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }
        InvokeRepeating("MakeAWave", 15f, 20f);
    }

    public void MakeAWave()
    {
        Instancja(GetRandomContainer());
    }

    private void Update()
    {
        if(go)
        {
            time += Time.deltaTime;

            birdAttack.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*velocity, 0);
            velocity += acc;
            if(time> maxTime)
            {
                if(maxTime>4f)
                {
                    maxTime -= .5f;
                }
                go = false;
                time = 0;
                Destroy(birdAttack);
            }
        }
    }

    public GameObject GetRandomContainer()
    {
        return children[Random.Range(0, transform.childCount - 1)];
    }

    public void Instancja(GameObject child)
    {
        if (!go)
        {
            birdAttack = Instantiate(child, child.transform.position, Quaternion.identity, transform);
            go = true;
        }
    }
}
