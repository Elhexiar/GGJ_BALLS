using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_playerBallManager : MonoBehaviour
{
    public Rigidbody playerBallRigidbody;

    public Vector3 playerBallGravity;
    public float playerBallGravityStrength = 9.8f;

    public float mouseXscale = 0.01f;

    public float mouseYscale = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        playerBallRigidbody.AddForce(playerBallGravity.normalized * playerBallGravityStrength);

        if(Input.GetAxis("Mouse X") != 0)
        {
            playerBallGravity.x += Input.GetAxis("Mouse X") * mouseXscale;
        }
        if(Input.GetAxis("Mouse Y") != 0)
        {
            playerBallGravity.z += Input.GetAxis("Mouse Y") * mouseYscale;
        }
        
    }
}
