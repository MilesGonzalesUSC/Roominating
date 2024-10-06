using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningTransition : MonoBehaviour
{
    Animator anim;
    GameObject GameManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        GameManager = GameObject.FindGameObjectWithTag( "GameManager" );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transition( )
    {
        anim.SetTrigger( "End" );
        GameManager.GetComponent<SceneController>().BackToMainMenu();
    }
}
