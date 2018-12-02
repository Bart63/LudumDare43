using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    public Transform LeftBottom;
    public GameObject bullet;
    public Transform arm;
    
    private float ratiox, ratioy;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ratiox = 1024.0f/(float)Screen.width;
        ratioy = 720.0f / (float)Screen.height;
        if (Input.GetMouseButtonDown(0))
        {
            int food = transform.parent.GetComponent<HeightOfBaloon>().currentFood;

            if (food > 0)
            {
                //FindObjectOfType<AudioManager>().Play("throw");
                transform.parent.GetComponent<HeightOfBaloon>().currentFood--; 
                transform.parent.GetComponent<HeightOfBaloon>().Weight -= 3;
                anim.SetBool("Mouse Input", true);
                Debug.Log("throw");
                Vector2 velo = LeftBottom.position + new Vector3(Input.mousePosition.x*ratiox,Input.mousePosition.y*ratioy) - arm.position;
                GameObject b = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity, transform);
                b.transform.localPosition = new Vector3(0, 0, 0);
                b.GetComponent<Rigidbody2D>().AddForce(velo * 20);
            }
        }
        else
        {
            anim.SetBool("Mouse Input", false);
        }
        

    }
}