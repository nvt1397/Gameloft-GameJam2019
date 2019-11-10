using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefEnemy : Enemy
{
    public Rigidbody2D enemy;
    // Danh sách các vị trí của cây ở đây.
    public List<GameObject> treesList = new List<GameObject>();
    public GameObject treeWasChoice;
    public GameObject light;
    GameManager manager;
    Vector3 direction, target;
    public float randomX;
    public float randomY;
    float tChange = 0f;

    float currentHP;

    [SerializeField]
    float time = 2f;

    public Transform tree;
    Vector3 startPos;

    public float moveSpeed = 2f;
    bool isHit = true;

    private void Start()
    {
        light.SetActive(false);
        
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        currentHP = manager.enemyMaxHp3;
        enemy = GetComponent<Rigidbody2D>();
        
        
        treeWasChoice = FindTree();
        tree = treeWasChoice.transform.transform;
        print("tree : " + tree.position);
        startPos = enemy.transform.position;
        target = new Vector3(tree.position.x, tree.position.y + 5);

    }



    private void Update()
    {
        // Nếu không có cây nào sẽ random di chuyễn
        if (manager.treeCount == 0)
        {
            moveEmptyTree();
        }
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //trường hợp nếu phi thuyền chuẩn bị hút cây về, nhưng cây đó đã bị hủy trong lúc phi thuyền đang bay. 
        if (manager.treeCount > 0)
        {
            if (isHit)
            {
                moveEnemy(tree);
            }
            if (isHit == false)
            {
                if(treeWasChoice != null) {
                    if (!treeWasChoice.GetComponent<TreeGrown>().isTaken)
                    {
                        treeWasChoice.GetComponent<TreeGrown>().isTaken = true;
                        StartCoroutine(Comeback(time));

                        followTarget();
                    }
                    else
                    {
                        StartCoroutine(Comeback(time));
                    }
                }
                else
                {
                    StartCoroutine(Comeback(time));
                }
                    
                
                
            }
        }
    }

    void followTarget()
    {

        Vector3 targetEnemy = new Vector3(enemy.position.x, enemy.position.y - 1.4f, 0);
        treeWasChoice.transform.position = Vector3.MoveTowards(treeWasChoice.transform.position, targetEnemy, 10 * Time.deltaTime * 0.5f);


    }

    IEnumerator Comeback(float timer)
    {

        yield return new WaitForSeconds(timer);
        
        treeWasChoice.transform.position = Vector3.MoveTowards(treeWasChoice.transform.position, startPos, moveSpeed * Time.deltaTime);
        //Slot slot = treeWasChoice.transform.parent.GetComponent<Slot>();
        //slot.HaveTree = false;
        treeWasChoice.transform.SetParent(gameObject.transform);
        manager.treeCount -= 1;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startPos, moveSpeed * Time.deltaTime);
        light.SetActive(true);
        if(transform.position == startPos) { Destroy(treeWasChoice); Destroy(gameObject); }

    }
    public void moveEnemy(Transform tree)
    {
        direction = (target - transform.position).normalized;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, moveSpeed * Time.deltaTime);
        if (Mathf.Approximately(tree.position.x, enemy.position.x))
        {
            isHit = false;
        }
    }

    GameObject FindTree()
    {
        print("tree list count: " + treesList.Count);
        GameObject tree = treesList[Random.Range(0, treesList.Count)];
        Debug.Log(tree.gameObject.name);
        return tree;
    }

    void moveEmptyTree()
    {
        float maxX = 9f;
        float minX = -9f;
        float maxY = 4f;
        float minY = 2f;


        float moveSpeed = 1f;

        if (Time.time >= tChange)
        {
            randomX = Random.Range(minX, maxX); // with float parameters, a random float
            randomY = Random.Range(minY, maxY); //  between -2.0 and 2.0 is returned
                                                // set a random interval between 0.5 and 1.5
            tChange = Time.time + Random.Range(3f, 5f);
        }
        // if object reached any border, revert the appropriate direction
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            randomX = -randomX;
        }
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            randomY = -randomY;
        }

        // make sure the position is inside the borders
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(randomX, randomY, 0f), moveSpeed * Time.deltaTime);
        print("enemy move khi ko co cay");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            currentHP -= manager.mainTurretDmg;
        }
        if (collision.gameObject.tag == "MiniBullet")
        {
            currentHP -= manager.minigunDmg;
        }
    }
    
}
