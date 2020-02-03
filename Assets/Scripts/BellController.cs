using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string BellRing = "";
    public GameObject bellBlock;
    private Animator anim;
    private int bellLevel;
    private bool bellLocked;
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

    public void gameOverBell() {
        anim.SetBool("GameOver", true);
        FMODUnity.RuntimeManager.PlayOneShot(BellRing);
    }

    //Updates the floor of the bell if the bell is not locked
    public void updateBell(int level) {
        if (!bellLocked) {
            bellLevel = level;
            anim.SetInteger("Bell Level", bellLevel);
            StartCoroutine(TemporarilyDeactivate(1.5f));
        }
    }

    //Cooroutine helper to enable and disable a invisible wall as the bell is moving to prevent 
    //players from trapping themselves
    private IEnumerator TemporarilyDeactivate(float duration) {
        bellBlock.SetActive(true);
        yield return new WaitForSeconds(duration);
        bellBlock.SetActive(false);
    }
}
