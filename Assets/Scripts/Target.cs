using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _targeyRigidbody;
    private float _maxTorque = 10.0f;
    private float _minSpeed = 12.0f;
    private float _maxSpeed = 16.0f;
    private float _xRange = 4.0f;
    private float _ySpawnPosition = 2.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the rigidbody component on the object.
        _targeyRigidbody = GetComponent<Rigidbody>();

        // Adds an upward force between a random value.
        _targeyRigidbody.AddForce(ApplyRandomUpwardForce(), ForceMode.Impulse);

        // Adds a random rotation on the object.
        _targeyRigidbody.AddTorque(
            x: ApplyRandomRotation(),
            y: ApplyRandomRotation(),
            z: ApplyRandomRotation(), ForceMode.Impulse);

        // Random position.
        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private float ApplyRandomRotation()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    // returns a random generated vector3.
    private Vector3 ApplyRandomUpwardForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    // returns a random generated vector 3 used for a spawn position.
    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(
            x: Random.Range(-_xRange, _xRange),
            y: -_ySpawnPosition,
            z: 0);
    }

    // If the player clicks on an object, destroy it.
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    // When the object goes out of view, destroy it.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}