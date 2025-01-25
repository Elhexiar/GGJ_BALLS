using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DeathCollider : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.gameObject.transform.position = GameObject.Find("GameManager").GetComponent<GameManager>().spawnPoint;
            GameObject.Find("PlayerBall").GetComponent<S_playerBallManager>().ResetGravity();
        }
    }
}
