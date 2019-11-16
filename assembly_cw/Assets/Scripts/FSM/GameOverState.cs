using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : FSMState

{
    private void Awake()
    {
        stateID = StateID.GameOver;
       
        AddTransition(Transition.OnStartButtonClick, StateID.Play);
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    void Update()

    {
        //enabled = false;
    }

    public void OnReStartButtonClick()
    {
        //Debug.Log("click");
        //popup = false;
        ////_lastDashButtonTime = Time.time;
        //isPause = false;
        control.view.HideOverUI();
        control.model.ReStart();
        control.gameManger.ReStart();
        control.view.TimeRestart();
        //control.gameManger.enabled = true;
        //control.gameManger.StartGame();
        control.gameManger.RecoverOver();
        fsm.PerformTransition(Transition.OnStartButtonClick);


        //if (Input.GetMouseButton(0) && control.view.leftMouse == false)
        //{
        //    Debug.Log("鼠标左键,playstate");
        //    control.view.leftMouse = true;
        //    fsm.PerformTransition(Transition.OnStartButtonClick);

        //}
        //fsm.PerformTransition(Transition.OnStartButtonClick);

    }

}
