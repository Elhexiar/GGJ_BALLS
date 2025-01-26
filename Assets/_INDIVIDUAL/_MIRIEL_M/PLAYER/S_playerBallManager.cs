using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_playerBallManager : MonoBehaviour
{
    public Rigidbody playerBallRigidbody;

    public GameObject cameraAnchor;

    public Vector3 playerBallGravity;
    public float playerBallGravityStrength = 9.8f;

    public float cameraRotationSpeed = 60f;

    public float mouseXscale = 0.01f;

    public float mouseYscale = 0.01f;


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

        //Screen.orientation = ScreenOrientation.LandscapeLeft;


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

        if (gameObject.GetComponent<Rigidbody>().linearVelocity.y < -20)
        {
            gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(
                gameObject.GetComponent<Rigidbody>().linearVelocity.x, -20, 
                gameObject.GetComponent<Rigidbody>().linearVelocity.z);
        }

        

        Vector3 adjustedGravity = playerBallGravity.normalized * playerBallGravityStrength;

        playerBallRigidbody.AddForce(cameraAnchor.transform.TransformDirection(adjustedGravity), ForceMode.Force);

        
        if (playerBallRigidbody.linearVelocity.magnitude > 40f)
        {
            playerBallRigidbody.linearVelocity = Vector3.ClampMagnitude(playerBallRigidbody.linearVelocity, 40f);
        }

        if (playerBallGravity.y > -1f)
        {
            playerBallGravity = new Vector3(playerBallGravity.x, -1f, playerBallGravity.z);
        }   
        Debug.Log(playerBallGravity);
        

        // Get the gyroscope rotation rate
        //Quaternion gyroRotation = Input.gyro.attitude;
        //Vector3 gyroRotation = Input.gyro.rotationRate;

        //print(gyroRotation);


        // Use the gyroscope data to adjust the gravity vector
        //playerBallGravity.x += -gyroRotation.y * mouseXscale;
        //playerBallGravity.z += gyroRotation.x * mouseYscale;
        


    }
}
