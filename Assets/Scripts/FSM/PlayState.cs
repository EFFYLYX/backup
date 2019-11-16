using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
    public bool isPause = true;

    private void Awake()
    {
        enabled = false;
        isPause = true;
        stateID = StateID.Play;
        AddTransition(Transition.Play2Pause, StateID.Pause);
        AddTransition(Transition.Play2Over, StateID.GameOver);

    }

    public bool popup = true;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    /// 
    ///      // Must double tap within half a second (by default)
    public float doubleTapTime = 2.0f;
    // Time to wait between dashes
    public float dashWaitTime = 2.0f;

    // Time that the dash button was last pressed
    private float _lastDashButtonTime;
    // Time of the last dash
    private float _lastDashTime;
    bool start = false;

    bool isDashPossible
    {
        get
        {
            return Time.time - _lastDashTime > dashWaitTime;
        }
    }

    void DoDoubleDash()
    {
        //_lastDashButtonTime = Time.time;
        //control.view.space_pause = true;
        //Debug.Log("您按下了空格键,playsage");
        ////fsm.PerformTransition(Transition.Play2Pause);
        //isPause = true;
        //control.gameManger.PauseGame();
                control.view.space_play = false;
                Debug.Log("您按下了空格键2,playsage");
                //fsm.PerformTransition(Transition.Play2Pause);
                control.view.Play();
                isPause = false;
                control.gameManger.StartGame();
        // blah...
    }
    void Update()
    {
        //Debug.Log("update,playsage");
        if (control.gameManger.CheckOver() && Input.GetKey(KeyCode.S))
        {
            //enabled =false;
            popup = false;
            //_lastDashButtonTime = Time.time;

            control.view.HideOverUI();
            control.model.ReStart();
            control.gameManger.ReStart();
            control.view.TimeRestart();

            control.gameManger.StartGame();
            isPause = false;
            //fsm.PerformTransition(Transition.Play2Over);
        }
        //if (control.gameManger.CheckOver()) { return; }

        if (!control.gameManger.CheckOver() && Input.GetKeyUp(KeyCode.Space))
        {
            if (isPause == true)
            {
                Debug.Log("resume");
                DoDoubleDash();
            }
            else
            {
                Debug.Log("pause");

                control.view.space_pause = true;
                //Debug.Log("您按下了空格键,playsage");
                //fsm.PerformTransition(Transition.Play2Pause);
                isPause = true;
                control.gameManger.PauseGame();
            }

        }


        

        //if (popup==false && Input.GetKeyUp(KeyCode.Space) )
        //{
        //    if (isPause== true)
        //    {
        //            Debug.Log("resume");
        //        DoDoubleDash();
        //    }
        //    else
        //    {
        //            Debug.Log("pause");

        //                    control.view.space_pause = true;
        //                    Debug.Log("您按下了空格键,playsage");
        //                    //fsm.PerformTransition(Transition.Play2Pause);
        //                    isPause = true;
        //                    control.gameManger.PauseGame();
        //    }

        //}



        ////if (isDashPossible && Input.GetKeyDown(KeyCode.D))
        //if (Input.GetKeyDown(KeyCode.Space) && popup == false)
        //{
        //    // If second time pressed?
        //    Debug.Log("dd");
        //    float t = Time.time - _lastDashButtonTime;
        //    if (Time.time - _lastDashButtonTime < doubleTapTime)
        //    {

        //        Debug.Log(t.ToString());
        //        if (isPause == true)
        //        {
        //            DoDoubleDash();
        //        }

        //    }
        //    else
        //    {
        //        Debug.Log("ttt");
        //        if (isPause == false)
        //        {
        //            _lastDashButtonTime = Time.time;
        //            control.view.space_pause = true;
        //            Debug.Log("您按下了空格键,playsage");
        //            //fsm.PerformTransition(Transition.Play2Pause);
        //            isPause = true;
        //            control.gameManger.PauseGame();

        //        }


        //    }
        //}
        //    if (Time.time - _lastDashButtonTime > doubleTapTime)
        //    {

        //        Debug.Log(t.ToString());
        //        if (isPause == true)
        //        {
        //            DoDoubleDash();
        //        }

        //    }


        //}


        //if (isPause == false)
        //{
        //    //control.view.TimeUp();



        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {


        //            control.view.space_pause = true;
        //            Debug.Log("您按下了空格键,playsage");
        //            //fsm.PerformTransition(Transition.Play2Pause);
        //            isPause = true;
        //            control.gameManger.PauseGame();
        //        }


        //}



        //if (isPause == true)
        //{
        //    //control.view.TimeUp();



        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {


        //        control.view.space_play = false;
        //        Debug.Log("您按下了空格键2,playsage");
        //        //fsm.PerformTransition(Transition.Play2Pause);
        //        control.view.Play();
        //        isPause = false;
        //        control.gameManger.StartGame();
        //    }


        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    if(isPause == true)
        //    {
        //        control.view.space_pause = true;
        //        Debug.Log("您按下了空格键,pause");
        //        //fsm.PerformTransition(Transition.Play2Pause);
        //        isPause = true;
        //        control.gameManger.PauseGame();
        //    }
        //    else
        //    {
        //                control.view.space_play = false;

        //                control.view.Play();
        //                //control.view.space_pause = true;
        //                Debug.Log("您按下了空格键,resume");
        //                //fsm.PerformTransition(Transition.Play2Pause);
        //                isPause = false;
        //                control.gameManger.StartGame();
        //    }

        //    //return;
        //}

        //if(isPause== true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        control.view.space_play = false;

        //        control.view.Play();
        //        //control.view.space_pause = true;
        //        Debug.Log("您按下了空格键,resume");
        //        //fsm.PerformTransition(Transition.Play2Pause);
        //        isPause = false;
        //        control.gameManger.StartGame();
        //        //return;
        //    }

        //}





        //if (isPause == false)
        //{

        //}
        //}
        //else
        //{
        //    return;
        //}


        //control.view.TimeStart();
    }
    void DisableKey(KeyCode key)
    {
        if (Event.current.keyCode == key && (Event.current.type == EventType.KeyUp || Event.current.type == EventType.KeyDown))
        {
            Event.current.Use();
        }
    }


    public override void DoBeforeEntering(){
        Debug.Log("enter");
        enabled = true;
        popup = false;
        //_lastDashButtonTime = Time.time;
        control.view.Play();
        isPause = false;
        control.gameManger.StartGame();
        //control.view.space_pause = false;
        //base.DoBeforeEntering();
    }
    public override void DoBeforeLeaving()
    {
        enabled = false;
        //control.view.space_pause = true;
        isPause =true;
        control.gameManger.PauseGame();
    }

    //public void OnReStartButtonClick()
    //{
    //    //enabled = true;
    //    popup = false;
    //    //_lastDashButtonTime = Time.time;
       
    //    control.view.HideOverUI();
    //    control.model.ReStart();
    //    control.gameManger.ReStart();
    //    control.view.TimeRestart();

    //    control.gameManger.StartGame();
    //    isPause = true;

    //    //if (Input.GetMouseButton(0) && control.view.leftMouse == false)
    //    //{
    //    //    Debug.Log("鼠标左键,playstate");
    //    //    control.view.leftMouse = true;
    //    //    fsm.PerformTransition(Transition.OnStartButtonClick);

    //    //}
    //    //fsm.PerformTransition(Transition.OnStartButtonClick);

    //}

}
