using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrown : MonoBehaviour
{

    int treeState;
    public int treeVal; 
    public int cleanVal;
    public int pastcleanVal;
    public bool canCut;
    bool isBig;
    bool isOld;
    bool isDead;

    public bool isTaken;
    GameManager manager;
    Animator anim;
    [SerializeField]
    float lifeCycleTime = 0;
    int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        isBig = isOld = isDead = false;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        treeState = 0;
        anim = GetComponent<Animator>();
        canCut = false;
        cleanVal = 1;
        manager.totalTreePower += cleanVal;
        pastcleanVal = 0;
        currentHP = 5;
        isTaken = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHP <= 0) {
            Slot slot = transform.parent.GetComponent<Slot>();
            slot.HaveTree = false;
            slot.tree = null;
            manager.treeCount--;
            Destroy(gameObject);
        }
        lifeCycleTime += Time.deltaTime;
        if (lifeCycleTime > 15f && isBig == false) {
            treeState = 1; treeVal = 10; cleanVal = 3; pastcleanVal = 1;
            manager.totalTreePower += (cleanVal - pastcleanVal);
            canCut = true;
            isBig = true;
        } //Big Tree
        if (lifeCycleTime > 30f && isOld == false) {
            treeState = 2; treeVal = 6; cleanVal = 2; pastcleanVal = 3;
            manager.totalTreePower += (cleanVal - pastcleanVal);
            isOld = true;
        } //Old Tree
        if (lifeCycleTime > 40f && isDead == false) {
            treeState = 3; treeVal = 3; cleanVal = 0; pastcleanVal = 2;
            manager.totalTreePower += (cleanVal - pastcleanVal);
            isDead = true;
        } //Dead Tree
        anim.SetInteger("TreeState", treeState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            currentHP--;
        }
    }
}
