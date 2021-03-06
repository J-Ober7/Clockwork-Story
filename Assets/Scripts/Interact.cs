﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    public string ID;
    public string hint;
    public LevelController lvlc;

    private bool hasCog;
    private GameObject cog;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Logic for switches to turn on and apply the appropriate effects
    public GameObject TurnOn(GameObject givenCog) {
        if (!hasCog) {
            cog = givenCog;
            hasCog = true;
            lvlc.Increase(ID);
            cog.GetComponent<Animator>().SetBool("Spin", true);
            cog.GetComponent<BoxCollider2D>().enabled = false;
            cog.transform.parent = transform;
            cog.transform.position = transform.position;
        }
        else {
            return givenCog;
        }
        return null;
    }

    //Logic for switches to turn off and disable their effects
    public GameObject TurnOff(GameObject givenCog) {
        if (!hasCog) {
            return givenCog;
        }
        else if (lvlc.Decrease(ID)) {
            GameObject temp = cog;
            cog.GetComponent<Animator>().SetBool("Spin", false);
            cog = null;
            hasCog = false;
            return temp;
            
        }
        return null;
    }
}
