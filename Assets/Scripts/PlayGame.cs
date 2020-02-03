using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string Win = "";
    private void Start() {
        FMODUnity.RuntimeManager.PlayOneShot(Win);
    }

    //for Main Menu Button to load the game scene
    public void PlayCogTower() {
        SceneManager.LoadScene("CogTower");
    }


    //for Main Menu and Endscreen Button to quit the game
    public void ExitGame() {
        Application.Quit();
    }
}
