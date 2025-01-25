using System;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private S_playerBallManager _player;
    //public CheckVelocity check;
    private float velocity;
    void Start()
    {
        _player = FindFirstObjectByType<S_playerBallManager>();
    }

    void Update()
    {
        velocity = _player.GetComponent<Rigidbody>().linearVelocity.magnitude;
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == _player.gameObject)
        {
            if (velocity >= 10f)
            {
                Destroy(gameObject);
            }
        }
    }
}
