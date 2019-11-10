using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
  
    public GameObject smoke;
    public float timeDispose;
    public bool startTiming;

    private Animator anim;
    
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        timeDispose = 10f;
        startTiming = false;
        anim = smoke.GetComponent<Animator>();
        
        active = false;
    }
    void Update()
    {
        if (timeDispose <= 0)
        {
            Destroy(gameObject);

        }
        else if(timeDispose <= 5)
        {
            active = true;
            anim.SetBool("Active", active);
        }
        CheckTouch();
        Debug.Log("we poisoning..");
        if(startTiming) timeDispose -= Time.deltaTime;
    }
    void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                Destroy(gameObject);

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            startTiming = true;
        }
    }

    // Update is called once per frame

}
