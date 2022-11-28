using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 colorNoPackage = new Color32(229, 0, 0, 255);
    [SerializeField] Color32 colorHasPackage = new Color32(0, 0, 0, 255);
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger with " + other.gameObject.name);

        if (other.tag == "Package" && !hasPackage)
        {
            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;
            spriteRenderer.color = colorHasPackage;
            Debug.Log("Package picked up!");
        }

        // If other gameObject tag is Customer, print "Delivery Complete"
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivery Complete");
            hasPackage = false;
            spriteRenderer.color = colorNoPackage;
        }
        else if (other.tag == "Customer" && !hasPackage)
        {
            Debug.Log("You don't have the package!");
        }
    }
}
