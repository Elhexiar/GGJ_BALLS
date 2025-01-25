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

    public float cameraRotationSpeed = 60f;

    public S_playerBallManager playerBallManager;

    public float cameraTiltStrength = 60f;



    void Start()
    {
        cameraOffset = cameraAnchor.transform.position - playerBall.transform.position; 
        cameraRotationOffset = cameraAnchor.transform.rotation.eulerAngles - playerBallManager.playerBallGravity;
        cameraAnchor.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        cameraAnchor.transform.position = playerBall.transform.position + cameraOffset;

        cameraAnchor.transform.rotation = Quaternion.Euler(new Vector3(playerBallManager.playerBallGravity.z*(-cameraTiltStrength), cameraAnchor.transform.rotation.eulerAngles.y, playerBallManager.playerBallGravity.x*(cameraTiltStrength)));

        if(Input.GetKey(KeyCode.Q))
        {
            cameraAnchor.transform.rotation = Quaternion.Euler(cameraAnchor.transform.rotation.eulerAngles.x, cameraAnchor.transform.rotation.eulerAngles.y - cameraRotationSpeed * Time.deltaTime, cameraAnchor.transform.rotation.eulerAngles.z);
            print("Q");
            print(cameraRotationSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.E))
        {
            cameraAnchor.transform.rotation = Quaternion.Euler(cameraAnchor.transform.rotation.eulerAngles.x, cameraAnchor.transform.rotation.eulerAngles.y + cameraRotationSpeed * Time.deltaTime, cameraAnchor.transform.rotation.eulerAngles.z);

            print("E");
        }

    
    }
}
