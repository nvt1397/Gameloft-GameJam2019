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
    public float totalTreePower;
    public int treeCount;
    [SerializeField]
    public int monsterCount;
    [SerializeField]
    float poisonPower;

    [SerializeField]
    float currentPollutionVal;  
    float currentHP = 100;

    int alienCount;

    public int currentCoin;
    //UI
    public Text timer;
    public Text currentCoinUI;
    public Slider HPSlider;
    public Slider OzoneSlider;

    public int enemyMaxHp1;
    public int enemyMaxHp2;
    public int enemyMaxHp3;

    public int mainTurretDmg;
    public int minigunDmg;

    public GameObject menu;
    public Text lastScore;
    // Start is called before the first frame update
    void Awake()
    {
        currentCoin = 5;
        //Init tree positions
        foreach(Transform child in treeManager.transform) {
            treePositions.Add(child.gameObject);
         }

        //Init gun positions
        foreach (Transform child in gunManager.transform)
        {
            gunPositions.Add(child.gameObject);
        }
        enemyMaxHp1 = 10;
        enemyMaxHp2 = 10;
        enemyMaxHp3 = 10;
        mainTurretDmg = 3;
        minigunDmg = 1;

        startPos = pollutionCloud.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveCloud();
        ChangePollutionVal();
        ApplyDmg();
        GameOver();
        UpdateUI();
        Debug.Log(monsterCount);
        
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


    private void ChangePollutionVal() {
        currentPollutionVal += ( + (monsterCount * poisonPower) - totalTreePower) * 0.8f * Time.deltaTime;
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
            lastScore.text = "Best Score: " + timer.text;
            Time.timeScale = 0f;
            menu.SetActive(true);
        }
    }
}
