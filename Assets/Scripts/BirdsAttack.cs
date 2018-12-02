using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsAttack : MonoBehaviour {
    public List<GameObject> children = new List<GameObject>();
    public List<GameObject> signs = new List<GameObject>();
    float time = 0f, maxTime=15f;
    GameObject birdAttack;
    bool go = false;
    public float velocity = 100f, acc = 2f;
    private void Start()
    {
        InvokeRepeating("MakeAWave", 15f, 20f);
    }

    public void MakeAWave()
    {
        StartCoroutine("Go");
    }

    IEnumerator Go()
    {
        int index = Random.Range(0, transform.childCount - 1);
        signs[index].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        signs[index].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        signs[index].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        signs[index].SetActive(false);
        yield return new WaitForSeconds(2f);
        Instancja(children[index]);
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
    
    public void Instancja(GameObject child)
    {
        if (!go)
        {
            birdAttack = Instantiate(child, child.transform.position, Quaternion.identity, transform);
            go = true;
        }
    }
}
