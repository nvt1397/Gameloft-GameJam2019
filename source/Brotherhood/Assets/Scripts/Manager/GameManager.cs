using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject pollutionCloud;

    public GameObject treeManager;
    public List<GameObject> treePositions;

    public GameObject gunManager;
    public List<GameObject> gunPositions;

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
    float currentHP = 100;

    public int currentCoin;
    //UI
    public Text timer;
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

    // Start is called before the first frame update
    void Awake()
    {
        //Init tree positions
        foreach(Transform child in treeManager.transform) {
            treePositions.Add(child.gameObject);
         }

        //Init gun positions
        foreach (Transform child in gunManager.transform)
        {
            gunPositions.Add(child.gameObject);
        }

        startPos = pollutionCloud.transform.position;


        //player bullet pool
        //playerBulletPool.InitPool(10,playerBullet);

        //enemy bullet
        //enemyBulletPool.InitPool(10, enemyBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveCloud();
        //CalculateTreePower();
        ChangePollutionVal();
        ApplyDmg();
        GameOver();
        UpdateUI();

        
    }

    private void UpdateUI()
    {
        currentCoinUI.text = currentCoin.ToString();
        timer.text = ((int)Time.timeSinceLevelLoad).ToString();
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
            GameObject tree = (GameObject)pos.GetComponentInChildren<GameObject>();          
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
    private void ApplyDmg()
    {
        if(currentPollutionVal >= 100)
        {
            currentHP -= (currentPollutionVal - 80f) * Time.deltaTime * 0.5f;
        }
    }
    private void GameOver()
    {
        if(currentHP <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
