using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    private int bellLevel;
    private int E1Level;
    private int E2Level;
    private bool bellLocked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increase(string ID) {

        if (ID.Equals("Bell")) {

        }else if (ID.Equals("BL")) {

        }else if (ID.Equals("E1")) {

        }else if (ID.Equals("E2")) {

        }else if (ID.Equals("Bell")) {

        }
    }
    public bool Decrease(string ID) {
        if (ID.Equals("Bell")) {
            if (!bellLocked) {
                bellLevel--;
            }
            else {
                return false;
            }

        }
        else if (ID.Equals("BL")) {

        }
        else if (ID.Equals("E1")) {

        }
        else if (ID.Equals("E2")) {

        }
        else if (ID.Equals("Bell")) {

        }

        return true;
    }
}
