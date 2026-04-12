using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class WaterBalloonManager : MonoBehaviour
{
     public static WaterBalloonManager Instance;

    [Header("Original Balloons (they arent in the scene anymore lol)")]
    [SerializeField] GameObject balloonPrefab;

    public int currentBalloons;
    [SerializeField] int amountOfBalloons = 10;

    void Start()
    {
        Instance = this;
        SpawnAll();
    }

    void SpawnAll()
    {
        for (int i = 0; i < amountOfBalloons; i++)
        {
            float spawnRadius = .2f;
            GameObject currentBalloon = Instantiate(balloonPrefab, transform.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius)), balloonPrefab.transform.rotation); //spawn it somewhere random in the spawn radius
            currentBalloon.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f,1f), Random.Range(0f, 1f));//random color lol
        }
        
        /*
        currentBalloons = 0;

        foreach (GameObject original in originalBalloons)
        {
            GameObject newBalloon = Instantiate(
                original,
                original.transform.position,
                original.transform.rotation
            );

            newBalloon.SetActive(true);
            currentBalloons++;
        }
        */

        Debug.Log("Balloons spawned: " + currentBalloons);
    }

    
    public void BalloonDestroyed()
    {
        currentBalloons--;

        if (currentBalloons <= 0)
        {
            Debug.Log("All balloons gone → respawn in 2s");
            SpawnAll();
        }
    }
}