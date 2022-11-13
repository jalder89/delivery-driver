using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Initialize the variables
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float steerSpeed = 100.0f;

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
}
