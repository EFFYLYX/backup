using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Start;
        AddTransition(Transition.OnStartButtonClick, StateID.Play);

    }
    public override void DoBeforeEntering()
    {
        control.view.ShowMenu();
        //control.view.TimeStart();

    }

    public override void DoBeforeLeaving()
    {
        control.view.HideMenu();
    }

    private void Start()
    {

    }

    public void OnStartButtonClick()
    {

        //if (Input.GetMouseButton(0) && control.view.leftMouse == false)
        //{
        //    Debug.Log("鼠标左键,playstate");
        //    control.view.leftMouse = true;
        //    fsm.PerformTransition(Transition.OnStartButtonClick);

        //}
        
        fsm.PerformTransition(Transition.OnStartButtonClick);

    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update() {
        //if (Input.GetMouseButton(0) && control.view.leftMouse == false)
        //{
        //    Debug.Log("鼠标左键,playstate");
        //    control.view.leftMouse = true;
        //    fsm.PerformTransition(Transition.OnStartButtonClick);

        //}
        //if (Input.GetMouseButton(0))
        //{
        //    fsm.PerformTransition(Transition.OnStartButtonClick);
        //}


        //AddTransition(Transition.Play, StateID.Play);
        //{
        //if (Input.GetMouseButton(0))
        //{
        //    //Debug.Log("Left Mouse Button Down");
        //    //t.GetComponent<Text>().text = "01:01";
        //    //control.view.TimeStart();
        //    //t.text = "01:01";

        //    fsm.PerformTransition(Transition.Play);
        //}
        //control.view.TimeStart();
    }
}
