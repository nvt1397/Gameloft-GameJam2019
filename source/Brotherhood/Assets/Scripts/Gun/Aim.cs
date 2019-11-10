using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public bool charging;
    public bool fireAllowed;

    public float delayChargingTime = 1f;
    public float ChargingTime = 1f;


    public float speed = 3f;
    public bool active;
    public Transform AimTarget;
    public GameObject bullet;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        fireAllowed = true;
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Active", active);
        ChargingTime = delayChargingTime;
        charging = false;
        active = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            if (!charging && fireAllowed)
            {
                charging = true;
                active = true;
                animator.SetBool("Active", active);
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
                animator.SetBool("Active", active);
                GameObject clone = Instantiate(bullet, AimTarget.position, AimTarget.rotation);
                clone.GetComponent<Rigidbody2D>().velocity = (AimTarget.up * speed);
            }
        }
    }

}
