using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _targeyRigidbody;
    private float _torqueRange = 10.0f;


    // Start is called before the first frame update
    private void Start()
    {
        // Get the rigidbody component on the object.
        _targeyRigidbody = GetComponent<Rigidbody>();

        ApplyRandomUpwardForce();
        ApplyRandomRotation();

        // Random position.
        transform.position = new Vector3(
            x: Random.Range(-4, 4),
            y: -6,
            z: 0);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Adds a random rotation on the object.
    private void ApplyRandomRotation()
    {
        _targeyRigidbody.AddTorque(
            x: Random.Range(-_torqueRange, _torqueRange),
            y: Random.Range(-_torqueRange, _torqueRange),
            z: Random.Range(-_torqueRange, _torqueRange), ForceMode.Impulse);
    }

    // Adds an upward force between a random value.
    private void ApplyRandomUpwardForce()
    {
        _targeyRigidbody.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
    }
}