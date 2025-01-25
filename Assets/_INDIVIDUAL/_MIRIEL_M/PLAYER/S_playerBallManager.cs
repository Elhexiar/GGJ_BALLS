using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_playerBallManager : MonoBehaviour
{
    public Rigidbody playerBallRigidbody;

    public GameObject cameraAnchor;

    public Vector3 playerBallGravity;

    private Vector3 defaultplayerBallGravity;
    public float playerBallGravityStrength = 9.8f;

    public float cameraRotationSpeed = 60f;

    public float mouseXscale = 0.01f;

    public float mouseYscale = 0.01f;

    public float maxLinearVelocity = 10f;

    //public float maxAngularVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Check if the device supports the gyroscope
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true; // Enable the gyroscope
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }

        // Set the default gravity vector
        defaultplayerBallGravity = playerBallGravity;
        //Screen.orientation = ScreenOrientation.LandscapeLeft;

        playerBallRigidbody.maxLinearVelocity = maxLinearVelocity;
        //playerBallRigidbody.maxAngularVelocity = maxAngularVelocity;
        


    }

    public void ResetGravity()
    {
        playerBallGravity = defaultplayerBallGravity;
    }
    // Update is called once per frame
    void Update()
    {


        if(Input.GetAxis("Mouse X") != 0)
        {
            playerBallGravity.x += Input.GetAxis("Mouse X") * mouseXscale;
        }
        if(Input.GetAxis("Mouse Y") != 0)
        {
            playerBallGravity.z += Input.GetAxis("Mouse Y") * mouseYscale;
        }
 

        

        Vector3 adjustedGravity = playerBallGravity.normalized * playerBallGravityStrength;

        playerBallRigidbody.AddForce(cameraAnchor.transform.TransformDirection(adjustedGravity), ForceMode.Force);


        

        // Get the gyroscope rotation rate
        //Quaternion gyroRotation = Input.gyro.attitude;
        //Vector3 gyroRotation = Input.gyro.rotationRate;

        //print(gyroRotation);


        // Use the gyroscope data to adjust the gravity vector
        //playerBallGravity.x += -gyroRotation.y * mouseXscale;
        //playerBallGravity.z += gyroRotation.x * mouseYscale;
        


    }
}
