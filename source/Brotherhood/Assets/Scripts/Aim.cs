using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public bool charging;
   

    public float delayChargingTime = 1f;
    public float ChargingTime = 1f;


    public float speed = 3f;
    public bool active;
    public Transform AimTarget;
    public GameObject bullet;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        ChargingTime = delayChargingTime;
        charging = false;
        active = false;
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Active", active);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!charging)
            {
                charging = true;
                active = true;
                anim.SetBool("Active", active);
                ChargingTime = delayChargingTime;
            }
        }
        if (charging)
        {
            ChargingTime -= Time.deltaTime;
            if (ChargingTime <= 0)
            {
                charging = false;
                active = false;
                anim.SetBool("Active", active);
                GameObject clone = Instantiate(bullet, AimTarget.position, AimTarget.rotation);
                clone.GetComponent<Rigidbody2D>().velocity = (AimTarget.up * speed);
            }
        }


        /*if (Input.touchCount > 0)
        {
            charging = true;
            if (charging)
            {
                if (delayTime <= 0) { charging = 0; }
                else delayTime -= Time.deltaTime;
            }
            if (delayTime <= 0 && !charging) {
                    
                    //Touch touch = Input.GetTouch(0);
                    //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    //touchPosition.z = 0;
                    //GameObject clone = Instantiate(bullet, AimTarget.position, AimTarget.rotation);
                   // clone.GetComponent<Rigidbody2D>().velocity = (AimTarget.up * speed);
                    //delayTime = delay2Shot;
                

            }
            else
            {
                delayTime -= Time.deltaTime;
                active = true;
                anim.SetBool("Active", active);
            }

        }*/

    }

}
