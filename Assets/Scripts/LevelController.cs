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

    public BellController Bell;
    public GameObject Elevator1;
    public GameObject Elevator2;
    public static bool gameWin;

    [FMODUnity.EventRef]
    public string BackMusic = "";
    FMOD.Studio.EventInstance musicState;

    [FMODUnity.EventRef]
    public string BellUp2 = "";
    [FMODUnity.EventRef]
    public string BellUp25 = "";
    [FMODUnity.EventRef]
    public string BellDown2 = "";
    [FMODUnity.EventRef]
    public string BellDown25 = "";
    [FMODUnity.EventRef]
    public string Sandbag = "";
    [FMODUnity.EventRef]
    public string WinMusic = "";
    [FMODUnity.EventRef]
    public string BellRing = "";
    [FMODUnity.EventRef]
    public string BellLock = "";
    [FMODUnity.EventRef]
    public string Ambiance = "";
    FMOD.Studio.EventInstance ambState;

    // Start is called before the first frame update
    void Start()
    {
        bellLevel = 0;
        E1Level = 0;
        E2Level = 0;
        lockLevel = 0;
        gameWin = false;
        musicState = FMODUnity.RuntimeManager.CreateInstance(BackMusic);
        musicState.start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increase(string ID) {

        if (ID.Equals("Bell")) {
            bellLevel++;
            if (!bellLocked) {
                if (bellLevel == 2) {
                    FMODUnity.RuntimeManager.PlayOneShot(BellUp25);
                    
                }
                else {
                    FMODUnity.RuntimeManager.PlayOneShot(BellUp2);
                }
                musicState.setParameterByName("bell_stage", bellLevel + 1);
            }
            Bell.updateBell(bellLevel);

        }
        else if (ID.Equals("BL")) {
            bellLocked = true;
            FMODUnity.RuntimeManager.PlayOneShot(BellLock);
            lockLevel = bellLevel;
            Bell.LockBell(true);

        }
        else if (ID.Equals("E1")) {
            E1Level++;
            if (E1Level == 1) {
                FMODUnity.RuntimeManager.PlayOneShot(Sandbag);
            }
            Elevator1.SetActive(true);
        }
        else if (ID.Equals("E2")) {
            E2Level++;
            if (E2Level == 1) {
                FMODUnity.RuntimeManager.PlayOneShot(Sandbag);
            }
            Elevator2.SetActive(true);
        }
        else if (ID.Equals("ED")) {
            E1Level++;
            Elevator1.SetActive(true);
            if (E1Level == 1) {
                FMODUnity.RuntimeManager.PlayOneShot(Sandbag);
            }
            E2Level++;
            if (E2Level == 1) {
                FMODUnity.RuntimeManager.PlayOneShot(Sandbag);
            }
            Elevator2.SetActive(true);
        }
        else if (ID.Equals("Ring")) {
            if(bellLevel == 2 || lockLevel == 2) {
                gameWin = true;
                Bell.gameOverBell();
                FMODUnity.RuntimeManager.PlayOneShot(BellRing);

            }
        }
    }
    public bool Decrease(string ID) {
        if (ID.Equals("Bell")) {
            if (!bellLocked) {
                if (bellLevel == 2) {
                    FMODUnity.RuntimeManager.PlayOneShot(BellDown25);
                }
                else {
                    FMODUnity.RuntimeManager.PlayOneShot(BellUp2);
                }
            }
            bellLevel--;
            Bell.updateBell(bellLevel);
        }
        else if (ID.Equals("BL")) {
            if (bellLocked) {
                if(bellLevel == lockLevel) {
                    bellLocked = false;
                    FMODUnity.RuntimeManager.PlayOneShot(BellLock);
                    Bell.LockBell(false);
                    return true;
                }
                else {
                    return false;
                }
            }
            
        }
        else if (ID.Equals("E1")) {
            E1Level--;
            if (E1Level < 1) {
                Elevator1.SetActive(false);
            }
        }
        else if (ID.Equals("E2")) {
            E2Level--;
            if(E2Level < 1) {
                Elevator2.SetActive(false);
            }
        }
        else if (ID.Equals("ED")) {
            E1Level--;
            E2Level--;
            if (E1Level < 1) {
                Elevator1.SetActive(false);
            }
            if (E2Level < 1) {
                Elevator2.SetActive(false);
            }
        }

        return true;
    }
}
