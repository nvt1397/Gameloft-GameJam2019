using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDrag : MonoBehaviour
{
    public bool collide = false;
    public GameObject barrel;
    private bool HaveGun;
    private bool inAslot;
    public GameObject gunSpawned;
    public GameObject slot;

    private bool touching;
    // Start is called before the first frame update
    void Start()
    {

        inAslot = false;
        HaveGun = false;
        touching = true;
        barrel = GameObject.FindGameObjectWithTag("Barrel");

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
                    {
                        barrel.GetComponent<Aim>().fireAllowed = false;
                        touching = true;
                        transform.position = new Vector2(touchPos.x, touchPos.y);

                    }
                    break;
                case TouchPhase.Moved:
                    barrel.GetComponent<Aim>().fireAllowed = false;
                    transform.position = new Vector2(touchPos.x, touchPos.y);
                    break;
                case TouchPhase.Ended:
                    barrel.GetComponent<Aim>().fireAllowed = true;
                    touching = false;
                    CheckDragToSlot();
                    Destroy(gameObject);

                    break;
            }
        }
        else
        {
            barrel.GetComponent<Aim>().fireAllowed = true;

            touching = false;
            CheckDragToSlot();
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collide = true;
        if (collision.gameObject.tag == "SlotGun")
        {
            inAslot = true;
            slot = collision.gameObject;
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collide = true;
        if (collision.gameObject.tag == "SlotGun")
        {
            inAslot = true;
            slot = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collide = false;
        if (collision.gameObject.tag == "SlotGun")
        {
            inAslot = false;

        }
    }
    private void CheckDragToSlot()
    {

        if (inAslot)
        {
            if (!touching)
            {
                HaveGun = slot.GetComponent<SlotGun>().HaveGun;
                if (!HaveGun)
                {

                    GameObject gun = Instantiate(gunSpawned, slot.transform.position + Vector3.down*0.25f, Quaternion.identity);
                    gun.transform.parent = slot.transform;
                    slot.GetComponent<SlotGun>().HaveGun = true;
                }
            }
        }


    }


}
