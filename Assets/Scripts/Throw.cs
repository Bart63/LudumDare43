using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    public Transform LeftBottom;
    public GameObject bullet;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 velo = LeftBottom.position + Input.mousePosition - transform.GetChild(0).position;
            GameObject b = Instantiate(bullet, new Vector3(0,0,0), Quaternion.identity, transform);
            b.transform.localPosition = new Vector3(0, 0, 0);
            b.GetComponent<Rigidbody2D>().AddForce(velo*20);
        }

        if (Input.GetMouseButton(0)) ;
        {
            FindObjectOfType<AudioManager>().Play("Throw");
        }

    }
}