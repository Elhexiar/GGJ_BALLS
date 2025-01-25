using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerBall;

    public Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = playerBall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RespawnPlayer()
    {
        playerBall.transform.position = spawnPoint;
    }
}
