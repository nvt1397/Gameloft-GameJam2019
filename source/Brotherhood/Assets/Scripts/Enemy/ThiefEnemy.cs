using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefEnemy : Enemy
{
    public Rigidbody2D enemy;
    public GameObject light;
    GameManager manager;
    // Danh sách các vị trí của cây ở đây.
    public List<GameObject> treesList = new List<GameObject>();

    Vector3 direction, target;
    public float randomX;
    public float randomY;
    float tChange = 0f;
    public float countTrees = 0;


    [SerializeField]
    float time = 2f;

    public Transform tree;
    Vector3 startPos;

    public float moveSpeed = 2f;
    bool isHit = true;

    private void Start()
    {

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        treesList = manager.treePositions;
        light = GetComponentInChildren<GameObject>();
        light.SetActive(false);
        enemy = GetComponent<Rigidbody2D>();
        tree = FindTree().transform.transform;
        startPos = enemy.transform.position;
        target = new Vector3(tree.position.x, tree.position.y + 5);

    }



    private void Update()
    {
        // Nếu không có cây nào sẽ random di chuyễn
        if (countTrees == 0)
        {
            moveEmptyTree();
            //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startPos, moveSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        //trường hợp nếu phi thuyền chuẩn bị hút cây về, nhưng cây đó đã bị hủy trong lúc phi thuyền đang bay. 
        if (countTrees > 0)
        {
            if (isHit)
            {
                moveEnemy(tree);
            }
            if (isHit == false)
            {
                StartCoroutine(Comeback(time));
            }
        }
    }
    IEnumerator Comeback(float timer)
    {

        yield return new WaitForSeconds(timer);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startPos, moveSpeed * Time.deltaTime);

    }
    public void moveEnemy(Transform tree)
    {
        direction = (target - transform.position).normalized;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, moveSpeed * Time.deltaTime);
        if (Mathf.Approximately(tree.position.x, enemy.position.x))
        {
            light.SetActive(true);
            isHit = false;
        }
    }

    GameObject FindTree()
    {
        print("find đc tree");
        GameObject tree = treesList[Random.Range(0, treesList.Count)];
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
            randomX = Random.Range(-9f, 9f); // with float parameters, a random float
            randomY = Random.Range(2f, 4.5f); //  between -2.0 and 2.0 is returned
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
}
