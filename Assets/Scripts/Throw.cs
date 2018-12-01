using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    public Transform LeftBottom;
    public GameObject bullet;
    public Transform arm;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int food = transform.parent.GetComponent<HeightOfBaloon>().currentFood;

            if (food > 0)
            {
                transform.parent.GetComponent<HeightOfBaloon>().currentFood--;
                anim.SetBool("Mouse Input", true);
                Debug.Log("Throw");
                Vector2 velo = LeftBottom.position + Input.mousePosition - arm.position;
                GameObject b = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity, transform);
                b.transform.localPosition = new Vector3(0, 0, 0);
                b.GetComponent<Rigidbody2D>().AddForce(velo * 20);
            }
        }
        else
        {
            anim.SetBool("Mouse Input", false);
        }

        if (Input.GetMouseButton(0))
        {
            FindObjectOfType<AudioManager>().Play("Throw");
        }

    }
}