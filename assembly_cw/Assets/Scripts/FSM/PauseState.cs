using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : FSMState
{
    bool good;

    bool isPause = false;
    private void Awake()
    {
        enabled = false;
        stateID = StateID.Pause;
        //current = false;
        AddTransition(Transition.Pause2Play, StateID.Play);
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public override void DoBeforeEntering()
    {
        enabled = true;
        control.view.Pause();
        isPause = true;
        //control.view.space_play = true;
        //base.DoBeforeEntering();
    }

    public override void DoBeforeLeaving()
    {
        //enabled = true;

        control.view.space_play = false;

        isPause = false;
    }
    private void Update()
    {

        //if( current == true)
        //{
        if (isPause == true)
        {
            //System.Threading.Thread.Sleep(1000);

            if (Input.GetKey(KeyCode.Space))
            {


                //Debug.Log("您按下了空格键,pausestate");

                //control.view.space = false;
                fsm.PerformTransition(Transition.Pause2Play);
                //return;

            }
        }

        //if (Input.GetKey(KeyCode.Space))
        //{


        //    Debug.Log("您按下了空格键,pausestate");

        //    //control.view.space = false;
        //    fsm.PerformTransition(Transition.Pause2Play);
        //    //return;

        //}

        //else
        //{
        //    return;
        //}

    }
}
