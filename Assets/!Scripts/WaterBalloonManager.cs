using System.Collections.Generic;
using UnityEngine;

public class WaterBalloonManager : MonoBehaviour
{
     public static WaterBalloonManager Instance;

    [Header("Original Balloons (Templates - DISABLE THEM IN SCENE)")]
    public List<GameObject> originalBalloons;

    private int currentBalloons;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnAll();
    }

    void SpawnAll()
    {
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

        Debug.Log("Balloons spawned: " + currentBalloons);
    }

    public void BalloonDestroyed()
    {
        currentBalloons--;

        if (currentBalloons <= 0)
        {
            Debug.Log("All balloons gone → respawn in 2s");
            Invoke(nameof(SpawnAll), 2f);
        }
    }
}