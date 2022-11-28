using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 colorHasPackage = new Color32(255, 255, 255, 255);

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger with " + other.gameObject.name);

        if (other.tag == "Package" && hasPackage)
        {
            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;
            Debug.Log("Package picked up!");
        }

        // If other gameObject tag is Customer, print "Delivery Complete"
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivery Complete");
            hasPackage = false;
        }
        else if (other.tag == "Customer" && !hasPackage)
        {
            Debug.Log("You don't have the package!");
        }
    }
}
