using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchItem : MonoBehaviour
{
    private bool HaveTree;

    public GameObject treeDrag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                       Instantiate(treeDrag, transform.position, Quaternion.identity);              
                    break;
            }
        }
    }
   
}
