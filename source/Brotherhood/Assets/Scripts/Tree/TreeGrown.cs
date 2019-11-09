using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrown : MonoBehaviour
{
    int currentHP;
    [SerializeField]
    int maxHP = 10;

    int treeState;

    int treeVal;
    public int cleanVal;
    public int pastcleanVal;
    bool canCut;

    Animator anim;
    [SerializeField]
    float lifeCycleTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        treeState = 0;
        anim = GetComponent<Animator>();
        canCut = false;
        currentHP = maxHP;
        cleanVal = 1;
        pastcleanVal = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeCycleTime += Time.deltaTime;
        if (lifeCycleTime > 15f) { treeState = 1; treeVal = 4; cleanVal = 3; pastcleanVal = 1;  canCut = true; } //Big Tree
        else if (lifeCycleTime > 30f) { treeState = 2; treeVal = 3; cleanVal = 2; pastcleanVal = 3; } //Old Tree
        else if (lifeCycleTime > 40f) { treeState = 3; treeVal = 2; cleanVal = 0; pastcleanVal = 2; } //Dead Tree
        anim.SetInteger("TreeState", treeState);
    }
}
