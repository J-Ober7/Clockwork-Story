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
    public void PlayCogTower() {
        SceneManager.LoadScene("CogTower");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
