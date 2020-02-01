using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract: MonoBehaviour {
    public GameObject pickUp;

    private GameObject cogHeld = null;
    private Transform oldCogHeldTransform = null;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Grab")) {
            if (cogHeld != null) {
                cogHeld.transform.parent = oldCogHeldTransform;
                cogHeld = null;
            } else if (pickUp != null) {
                cogHeld = pickUp;
                oldCogHeldTransform = cogHeld.transform.parent;
                cogHeld.transform.parent = transform;
                pickUp = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if(interactable != null) {




            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            pickUp = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Interactable")) {
            interactable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            pickUp = null;
        }
        if (collision.gameObject.CompareTag("Interactable")) {
            interactable = null;
        }
    }
}
