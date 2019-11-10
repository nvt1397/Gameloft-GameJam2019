using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGunIcon : MonoBehaviour
{
    public GameObject gunDrag;

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
                        Instantiate(gunDrag, transform.position, Quaternion.identity);
                    break;
            }
        }
    }

}
