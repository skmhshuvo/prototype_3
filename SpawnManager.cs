using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("RecreateObs", 2, 2);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RecreateObs()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, new Vector3(25, 0, 0), obstaclePrefab.transform.rotation);
        }
    }
}


