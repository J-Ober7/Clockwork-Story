using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    private int bellLevel;
    private int E1Level;
    private int E2Level;
    private bool bellLocked;
    private int lockLevel;
    // Start is called before the first frame update
    void Start()
    {
        bellLevel = 0;
        E1Level = 0;
        E2Level = 0;
        lockLevel = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increase(string ID) {

        if (ID.Equals("Bell")) {
            bellLevel++;

        }
        else if (ID.Equals("BL")) {
            bellLocked = true;
            lockLevel = bellLevel;

        }
        else if (ID.Equals("E1")) {
            E1Level++;
        }
        else if (ID.Equals("E2")) {
            E2Level++;
        }
        else if (ID.Equals("ED")) {
            E1Level++;
            E2Level++;
        }
    }
    public bool Decrease(string ID) {
        if (ID.Equals("Bell")) {
            bellLevel--;

        }
        else if (ID.Equals("BL")) {
            if (bellLocked) {
                if(bellLevel == lockLevel) {
                    bellLocked = false;
                    return true;
                }
                else {
                    return false;
                }
            }
            
        }
        else if (ID.Equals("E1")) {
            E1Level--;
        }
        else if (ID.Equals("E2")) {
            E2Level--;
        }
        else if (ID.Equals("ED")) {
            E1Level--;
            E2Level--;
        }

        return true;
    }
}
