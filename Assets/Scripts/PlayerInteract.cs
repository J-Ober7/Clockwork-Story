using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract: MonoBehaviour {
    private bool hasCog;
    private GameObject cogHeld;
    public GameObject pickUp;

    // Start is called before the first frame update
    void Start() {
        hasCog = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Grab")) {
            if (hasCog) {
                cogHeld.transform.position = new Vector3(transform.position.x, transform.position.y, cogHeld.transform.position.z);
                cogHeld.SetActive(true);
                hasCog = false;
            } else if (pickUp != null) {
                hasCog = true;
                cogHeld = pickUp;
                cogHeld.SetActive(false);
                pickUp = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            pickUp = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            pickUp = null;
        }
    }
}
