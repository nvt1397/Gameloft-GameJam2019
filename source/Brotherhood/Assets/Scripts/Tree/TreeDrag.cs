using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDrag : MonoBehaviour
{
    private bool HaveTree;
    private bool inAslot;
    public GameObject treeSpawned;
    public GameObject slot;

    public GameManager manager;
    private bool touching;
    // Start is called before the first frame update
    void Start()
    {
        inAslot = false;
        HaveTree = false;
        touching = true;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
                        touching = true;
                        transform.position = new Vector2(touchPos.x, touchPos.y);

                    }
                    break;
                case TouchPhase.Moved:
                    transform.position = new Vector2(touchPos.x, touchPos.y);
                    break;
                case TouchPhase.Ended:
                    touching = false;
                    CheckDragToSlot();
                    Destroy(gameObject);

                    break;
            }
        }
        else
        {
            touching = false;
            CheckDragToSlot();
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree") {
            inAslot = true;
            slot = collision.gameObject;
        }
        

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            inAslot = true;
            slot = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
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
                HaveTree = slot.GetComponent<Slot>().HaveTree;
                if (!HaveTree)
                {
                    if(manager.currentCoin >= 2) {
                        manager.treeCount += 1;
                        slot.GetComponent<Slot>().tree = Instantiate(treeSpawned, slot.transform.position + new Vector3(0, 1f), Quaternion.identity);
                        slot.GetComponent<Slot>().tree.transform.parent = slot.transform;
                        manager.currentCoin -= 2;
                        slot.GetComponent<Slot>().HaveTree = true;
                    }
                    
                }
            }
        }
        
       
    }

}
