using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : MonoBehaviour
{
    private int bellLevel;
    private bool bellLocked;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bellLevel = 0;
        bellLocked = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets the lock state of the bell, bellLevel cannot change while locked
    public void LockBell(bool b) {
        bellLocked = b;
    }

    //Updates the floor of the bell if the bell is not locked
    public void updateBell(int level) {
        if (!bellLocked) {
            bellLevel = level;
            anim.SetInteger("Bell Level", bellLevel);
        }
    }
}
