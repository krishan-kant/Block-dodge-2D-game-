using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject blockPrefab;
    // Start is called before the first frame update
    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 1f;
    public Text currentS;
    int count=-1;

    public Text highScore;
    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            //spawning the blocks
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
            
            //increasing the score
            count += 1;
            currentS.text = count.ToString();

            //updating high score
            if (count > PlayerPrefs.GetInt("HighScore",0))
            {
                PlayerPrefs.SetInt("HighScore", count);
                highScore.text = count.ToString();
            }
        }
    }
    
    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnpoints.Length);

        for (int i = 0; i < spawnpoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spawnpoints[i].position, Quaternion.identity);
            }
        }
    }
}
