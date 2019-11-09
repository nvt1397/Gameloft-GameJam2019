using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    GameObject player;
    public GameObject pollutionCloud;

    public GameObject treeManager;
    public List<GameObject> treePositions;

    Vector3 startPos;
    [SerializeField]
    float speed;
    //Fields
    float totalTreePower;

    [SerializeField]
    int monsterCount;
    [SerializeField]
    float monsterPower;

    [SerializeField]
    float currentPollutionVal;  
    int currentHP;
    [SerializeField]
    int currentCoin;
    //UI
    public Text currentCoinUI;
    public Slider HPSlider;
    public Slider OzoneSlider;
    //Init Game Start
    //player bullet
    public GameObject playerBullet;
    public ObjectPooling playerBulletPool;

    //enemy bullet
    public GameObject enemyBullet;
    public ObjectPooling enemyBulletPool;

    //Enemy1
    public GameObject enemy1;
    public ObjectPooling enemy1Pool;
    //Enemy2
    public GameObject enemy2;
    public ObjectPooling enemy2Pool;
    //Enemy3
    public GameObject enemy3;
    public ObjectPooling enemy3Pool;

    //tree
    public GameObject tree;
    public ObjectPooling treePool;

    //minigun
    public GameObject minigun;
    public ObjectPooling minigunPool;

    // Start is called before the first frame update
    void Awake()
    {
        //Init tree positions
        foreach(Transform child in treeManager.transform) {
            treePositions.Add(child.gameObject);
         }

        player = GameObject.FindGameObjectWithTag("Player");
        startPos = pollutionCloud.transform.position;

        //player bullet pool
        //playerBulletPool.InitPool(10,playerBullet);

        //enemy bullet
        //enemyBulletPool.InitPool(10, enemyBullet);

        //Enemy1
        //enemy1Pool.InitPool(10, enemy1);
        //Enemy2
        //enemy2Pool.InitPool(10, enemy2);
        //Enemy3
        //enemy3Pool.InitPool(10, enemy3);

        //tree
        //treePool.InitPool(10, tree);

        //minigun

        //minigunPool.InitPool(6, minigun);
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveCloud();
        //CalculateTreePower();
        ChangePollutionVal();
        UpdateUI();
        
    }

    private void UpdateUI()
    {
        currentCoinUI.text = currentCoin.ToString();
        currentHP = Mathf.Clamp(currentHP, 0, 100);
        HPSlider.value = currentHP;
        currentPollutionVal = Mathf.Clamp(currentPollutionVal, 0, 100);
        OzoneSlider.value = 100 - currentPollutionVal;
    }
    private void MoveCloud()
    {
        Vector3 nextPosition = new Vector3(startPos.x,startPos.y - currentPollutionVal*0.15f,startPos.z);
        pollutionCloud.transform.position = Vector3.MoveTowards(pollutionCloud.transform.position, nextPosition, speed * Time.deltaTime);
    }

    private void CalculateTreePower()
    {
        foreach(GameObject pos in treePositions)
        {
            //GameObject tree = pos.GetComponent<Slot>().tree;          
            if (tree != null)
            {
                TreeGrown treeStat = tree.GetComponent<TreeGrown>();
                totalTreePower += treeStat.cleanVal - treeStat.pastcleanVal;
            }
        }
    }
    private void ChangePollutionVal() {
        currentPollutionVal += ( + (monsterCount * monsterPower) - totalTreePower) * 0.8f * Time.deltaTime;
        currentPollutionVal = Mathf.Clamp(currentPollutionVal, 0, 100);
    }
}
