using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCut : MonoBehaviour
{
    private bool HaveTree;
    private bool inAslot;
    public GameObject treeSpawned;
    public GameObject slot;
    private bool touching;

    GameManager manager;
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
        if (collision.gameObject.tag == "Tree")
        {
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
                Slot thisSlot = slot.GetComponent<Slot>();
                HaveTree = thisSlot.HaveTree;
                if (HaveTree)
                {
                    GameObject treecut = thisSlot.transform.GetChild(0).gameObject;
                    TreeGrown stat = treecut.GetComponent<TreeGrown>();
                    if (stat.canCut) {
                        manager.currentCoin += stat.treeVal;
                        manager.totalTreePower -= stat.cleanVal;
                        manager.treeCount -= 1;
                        Destroy(treecut);
                        thisSlot.tree = null;
                        thisSlot.HaveTree = false;
                    }
                    
                }
            }
        }


    }
}
