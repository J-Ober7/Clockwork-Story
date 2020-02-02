using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHelp : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() {
        anim.SetBool("On", true);
    }
    private void OnDisable() {
        anim.SetBool("On", false);
    }
}
