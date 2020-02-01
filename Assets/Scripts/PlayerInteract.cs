using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract: MonoBehaviour {
    public GameObject holdZone;

    private GameObject pickUp = null;
    private GameObject cogHeld = null;
    private Transform oldCogHeldTransform = null;
    private GameObject interactable = null;
    private ElevatorTeleporter elevator = null;

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
                cogHeld.transform.position = holdZone.transform.position;
                pickUp = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if(interactable != null) {
                if(cogHeld != null) {
                    cogHeld = interactable.GetComponent<Interact>().TurnOn(cogHeld);
                }
                else {
                    cogHeld = interactable.GetComponent<Interact>().TurnOff(cogHeld);
                }
            }
            if (elevator != null) {
                Vector3 elevatorPosition = elevator.other.transform.position;
                transform.position = new Vector3(elevatorPosition.x, elevatorPosition.y, transform.position.z);
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
        if (collision.gameObject.CompareTag("Elevator")) {
            elevator = collision.gameObject.GetComponent<ElevatorTeleporter>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            if (collision.gameObject == pickUp)
                pickUp = null;
        }
        if (collision.gameObject.CompareTag("Interactable")) {
            if(collision.gameObject == interactable)
                interactable = null;
        }
        if (collision.gameObject.CompareTag("Elevator")) {
            if(collision.gameObject.GetComponent<ElevatorTeleporter>() == elevator)
                elevator = null;
        }
    }
}
