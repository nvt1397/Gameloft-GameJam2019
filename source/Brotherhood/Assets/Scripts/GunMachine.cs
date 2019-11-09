using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMachine : MonoBehaviour
{

    public int Hp;
    public float AngleLimited;
    private Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 5;
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            transform.eulerAngles = new Vector3(0, 0, getAngleOfVector2(touchPosition - transform.position)-90);
            Debug.DrawLine(transform.position, touchPosition, Color.red);
          
        }
    }
    private float getAngleOfVector2(Vector2 v)
    {
        
       // return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
       return Mathf.Clamp(Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg, AngleLimited, 180-AngleLimited);
    }
}
