using System;
using Unity.VisualScripting;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    
    private S_playerBallManager _player;
    private Rigidbody _rigidbody;
    public float geyserPower = 100;

    void Start()
    {
        _player = FindFirstObjectByType<S_playerBallManager>();
        _rigidbody = _player.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.linearVelocity = new Vector3(0, geyserPower, 0);
    }
}
