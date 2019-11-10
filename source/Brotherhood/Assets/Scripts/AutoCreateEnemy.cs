using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoCreateEnemy : MonoBehaviour
{
	//Array of objects to spawn
    public List<GameObject> enemysList = new List<GameObject>();

    public float timeStartEnemyMoiTruong = 20f;
    public float timeStartEnemyThief = 30f;

    //Time it takes to spawn theGoodies
    [Space(3)]
	public float theCountdown = 10;

	// the range of X
	[Header("X Spawn Range")]
	public float xMin = -9f;
	public float xMax = 9f;

	// the range of y
	[Header("Y Spawn Range")]
	public float yMin = 5.5f;
	public float yMax = 6f;

    public float time = 5;
    // Hàm thời gian sinh quái
    public float timeWaitingForNextSpawn()
    {
        return time;
    }

	public void Update()
	{

        float waitingForNextSpawn = timeWaitingForNextSpawn();
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
		if (theCountdown <= 0)
		{
			SpawnEnemy();
			theCountdown = waitingForNextSpawn;
		}
	}


	void SpawnEnemy()
	{
		// Defines the min and max ranges for x and y
		Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        // Choose a new goods to spawn from the array (note I specifically call it a 'prefab' to avoid confusing myself!)
        GameObject enemy = enemysList[Random.Range(1, enemysList.Count -1)];

		// Creates the random object at the random 2D position.
		Instantiate(enemy, pos, transform.rotation);

		// If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
		//GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
		//newgoods.something = somethingelse;
	}
}
