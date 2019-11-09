using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipScript : MonoBehaviour
{
    //float speed = 12f;
    // Start is called before the first frame update
    Vector3 move;
    void Start()
    {
        move = transform.position;
    }

    // Update is called once per frame
    void Update()
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    transform.position = touchPosition;
                }

            }
}
