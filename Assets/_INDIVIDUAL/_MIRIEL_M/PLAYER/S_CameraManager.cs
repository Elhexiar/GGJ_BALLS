using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cameraAnchor;
    public GameObject playerBall;

    public Vector3 cameraOffset;

    public Vector3 cameraRotationOffset;

    public Vector3 cameraRotationTest;

    public S_playerBallManager playerBallManager;

    public float cameraTiltStrength = 60f;



    void Start()
    {
        cameraOffset = cameraAnchor.transform.position - playerBall.transform.position; 
        cameraRotationOffset = cameraAnchor.transform.rotation.eulerAngles - playerBallManager.playerBallGravity;
    }

    // Update is called once per frame
    void Update()
    {
        cameraAnchor.transform.position = playerBall.transform.position + cameraOffset;

        cameraAnchor.transform.rotation = Quaternion.Euler(new Vector3(playerBallManager.playerBallGravity.z*(cameraTiltStrength), 180, playerBallManager.playerBallGravity.x*(-cameraTiltStrength)));



    
    }
}
