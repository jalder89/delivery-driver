using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    // Initialize the variables
    [SerializeField] float defaultSpeed = 10.0f;
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float steerSpeed = 100.0f;
    [SerializeField] float slowSpeed = 5.0f;
    [SerializeField] float slowDuration = 2.0f;
    [SerializeField] float boostSpeed = 15.0f;
    [SerializeField] float boostDuration = 2.0f;

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical inputs
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        // Update the position and rotation
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount);
    }

    // OnTriggerEnter2D that sets moveSpeed to boostSpeed, and then after boostDuration seconds, sets moveSpeed back to defaultSpeed
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boost!");
            StartCoroutine(BoostTimer());
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        // If other gameObject is untagged, set moveSpeed to slowSpeed
        if (other.gameObject.tag == "Slow")
        {
            moveSpeed = slowSpeed;
            Debug.Log("Crash!");
            StartCoroutine(SlowTimer());
        }
    }

    // Coroutine that sets moveSpeed back to defaultSpeed after boostDuration seconds
    IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(boostDuration);
        moveSpeed = defaultSpeed;
    }

    // Coroutine that sets moveSpeed back to defaultSpeed after slowDuration seconds
    IEnumerator SlowTimer()
    {
        yield return new WaitForSeconds(slowDuration);
        moveSpeed = defaultSpeed;
    }

}
