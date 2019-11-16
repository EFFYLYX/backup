using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{   [HideInInspector]
    public Model model;
    [HideInInspector]
    public View view;

    [HideInInspector]
    public GameManager gameManger;

    private FSMSystem fsm;
    public PlayState playState;
   
    // Start is called before the first frame update
    void Start()
    {
        MakeFSM();
    } 
    public void Awake()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        gameManger = GetComponent<GameManager>(); 


    }

    public void SetTransition(Transition t) { fsm.PerformTransition(t); }
    void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach(FSMState state in states)
        {
            fsm.AddState(state,this);
        }
        StartState s = GetComponentInChildren<StartState>();
        fsm.SetCurrentState(s);

        playState = GetComponentInChildren<PlayState>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    //Debug.Log("Left Mouse Button Down");
        //    //t.GetComponent<Text>().text = "01:01";
        //    //control.view.TimeStart();

        //    //t.text = "01:01";
        //    SetTransition(Transition.Play);
        //    //fsm.PerformTransition(Transition.Play);
        //}

    }

    public void updatestate()
    {
        //Debug.Log("d");
        ////playState = GetComponentInChildren<PlayState>();
        //playState.enabled = false;
        //playState.popup = true;
        //if (playState.popup == true)
        //{
        //    Debug.Log("true");

        //}
        //else
        //{
        //    Debug.Log("false");
        //}


    }
}
