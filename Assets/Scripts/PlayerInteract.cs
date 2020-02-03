using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerInteract: MonoBehaviour {
    public GameObject holdZone;
    public TextMeshProUGUI t;
    public Image tImage;
    public TextMeshProUGUI WinText;
    public Image wImage;
    [FMODUnity.EventRef]
    public string GearDrop = "";
    [FMODUnity.EventRef]
    public string GearPlace = "";
    [FMODUnity.EventRef]
    public string GearPickup = "";

    private GameObject pickUp = null;
    private GameObject cogHeld = null;
    private Transform oldCogHeldTransform = null;
    private GameObject interactable = null;
    private ElevatorTeleporter elevator = null;
    

    // Start is called before the first frame update
    void Start() {
        WinText.enabled = false;
        wImage.enabled = false;
    }

    // Update is called once per frame
    //Handles Player E and Q inputs, for interacting with the world and picking up and dropping cogs respectively
    void Update() {
        if (!LevelController.gameWin) {
            if (Input.GetButtonDown("Grab")) {
                if (cogHeld != null) {
                    cogHeld.transform.parent = oldCogHeldTransform;
                    cogHeld = null;
                    FMODUnity.RuntimeManager.PlayOneShot(GearDrop);
                }
                else if (pickUp != null) {
                    cogHeld = pickUp;
                    oldCogHeldTransform = cogHeld.transform.parent;
                    cogHeld.transform.parent = transform;
                    cogHeld.transform.position = holdZone.transform.position;
                    pickUp = null;
                    FMODUnity.RuntimeManager.PlayOneShot(GearPickup);
                }
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                if (interactable != null) {
                    if (cogHeld != null) {
                        cogHeld = interactable.GetComponent<Interact>().TurnOn(cogHeld);
                        FMODUnity.RuntimeManager.PlayOneShot(GearPickup);
                    }
                    else {
                        cogHeld = interactable.GetComponent<Interact>().TurnOff(cogHeld);
                        if (cogHeld != null) {
                            FMODUnity.RuntimeManager.PlayOneShot(GearPickup);
                            cogHeld.GetComponent<BoxCollider2D>().enabled = true;
                            cogHeld.transform.parent = transform;
                            cogHeld.transform.position = holdZone.transform.position;
                        }
                    }
                }
                if (elevator != null) {
                    Vector3 elevatorPosition = elevator.other.transform.position;
                    transform.position = new Vector3(elevatorPosition.x, elevatorPosition.y, transform.position.z);
                }
            }
        }
        else {
            if (t != null) {
                t.enabled = false;
                tImage.enabled = false;
            }

            WinText.enabled = true;
            wImage.enabled = true;
        }

    }

    //Determines what trigger the player has hit and stores them as needed 
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            pickUp = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Interactable")) {
            interactable = collision.gameObject;
            t.text = collision.gameObject.GetComponent<Interact>().hint;
            tImage.enabled = true;
        }
        if (collision.gameObject.CompareTag("Elevator")) {
            elevator = collision.gameObject.GetComponent<ElevatorTeleporter>();
        }
    }


    //Determines what trigger the player is leave to remove them as needed
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            if (collision.gameObject == pickUp)
                pickUp = null;
        }
        if (collision.gameObject.CompareTag("Interactable")) {
            if (collision.gameObject == interactable) {
                interactable = null;
                t.text = "";
                tImage.enabled = false;
            }
        }
        if (collision.gameObject.CompareTag("Elevator")) {
            if(collision.gameObject.GetComponent<ElevatorTeleporter>() == elevator)
                elevator = null;
        }
    }
}
