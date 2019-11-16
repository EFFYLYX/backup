using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    Control control;
    bool isPause = false;
    private float timer = 0;
    private float stepTime = 0.5f;

    bool hasFallen = false;

    public bool scoreV = false;
    public bool scoreH = false;

    public bool moveLeft = false;
    public bool moveRight = false;
    public bool destroy = false;

    bool mL = false;

    public Left left;
    public Right right;

    private GameManager gameManager;

    private void Update()
    {
        if (isPause)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > stepTime)
        {
            timer = 0;
            Fall();
                    }

        if (this.tag != "Debris")
        {
            if (mL == true)
            {
                MoveRight();
                mL = false;

            }
            //if(this.left.left == true)
            //{
            //    MoveLeft();
            //    this.left.left = false;
            //}
            //if (left.left == true)
            //{
            //    MoveLeft();
            //    left.left = false;
            //}

            if (this.right.right == true)
            {
                MoveLeft();
                this.right.right = false;
            }
        }

        if (this.tag == "Debris")
        {
            Debug.Log("debris move");
            if (this.left.left == true)
            {

                Debug.Log("debris left");
                MoveRight();
                this.left.left = false;
            }

            if (this.right.right == true)
            {
                Debug.Log("debris right");
                MoveLeft();
                this.right.right = false;
            }
        }


        //InputControl();
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    //Debug.Log("DestroyDebris");
    //    //if (this.tag == "Debris")
    //    //{
    //    //    destroy = true;
    //    //}
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Stay");


        if (this.tag != "Debris")
        {
            //Debug.Log("left");

            //MoveLeft();
            mL = true;
        }


        if ( this.tag == "Debris")
        {
            //Debug.Log("DestroyDebris");
            destroy = true;

        }

        //if(this.tag == "Blue" && moveLeft==false) { 
        
        //MoveLeft(); }

        //if (this.tag == "Red" && moveLeft == false) { 

        //    MoveRight();
        //}
        //if (this.tag == "Green" && moveLeft == false) { 
        //MoveRight(); }



    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (enter)
    //    //{
    //         Debug.Log("entered");
    //    //}
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //if (exit)
    //    //{
    //        Debug.Log("exit");
    //    //}
    //}

    public void Init(GameManager gameManager,Control control)
    {
        this.gameManager = gameManager;
        this.control = control;
        //if (this.tag != "Debris")
        //{
        //    left= GetComponentInChildren<Left>();
        //    right = GetComponentInChildren<Right>();

        //}

    }
    public void Pause()
    {
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
    }

    public void MoveDown()
    {
        Vector3 pos = transform.position;
        pos.y -= 1.0f;
        transform.position = pos;
        control.model.PlaceShape2(pos, this);

    }

 
    public void Fall()
    {
        Vector3 pos = transform.position;
        pos.y -= 1.0f;
        transform.position = pos;
        //Debug.Log(transform.position.toString());

        //if (pos.y < -5)
        //{
        //    //pos.y += 1;
        //    pos.y =(float)Math.Truncate(pos.y);
        //    transform.position = pos;
        //    isPause = true;
        //    gameManager.FallDown();
        //}


        if (control.model.IsValidMapPosition(transform)==false)
        {
            //Vector3 temp = p

            //pos.y = (float)Math.Truncate(pos.y);
            //pos.y = (float)Math.Truncate(pos.y);


            //pos.y= (float)Mathf.RoundToInt(pos.y);
            pos.y = (float)Math.Ceiling(pos.y);
            transform.position = pos;
            isPause = true;


            int x = (int)pos.x + 2;
            int y = (int)pos.y + 5;

            gameManager.FallDown(this.tag , x, y);

            gameManager.mList.Remove(this);







            //string k = Mathf.RoundToInt(pos.x).ToString() + "," + pos.y.ToString();
            //Debug.Log(k);


            //control.model.badguys.Add(pos,this);

            control.model.PlaceShape(pos, this);



            //int x = (int)pos.x + 2;
            //int y = (int)pos.y + 5;

            //control.model.map[x, y] = this;

            hasFallen = true;

            //control.model.CheckVertical();

            //if (!control.model.badguys.ContainsKey(transform.position.toString())){
            //    //control.model.badguys.Add(pos.Round(), this);
            //    control.model.badguys.Add(transform.position.toString(), this);

            //}
            //else
            //{
            //    string k = Mathf.RoundToInt(pos.y).ToString() + "," + (pos.y + 1).ToString();
            //    control.model.badguys.Add(k, this);
            //}



            //if (pos.Round().y >0)
            //{

            //}

        }



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveLeft()
    {
        float h = -1;
        Vector3 pos = transform.position;
        pos.x += h;
        transform.position = pos;
        if (control.model.IsValidMapPosition(transform) == false)
        {
            pos.x -= h;

            transform.position = pos;
            //control.model.badguys.Add(pos, this);
        }

    }
    public void MoveRight()
    {
        float h = 1;
        Vector3 pos = transform.position;
        pos.x += h;
        transform.position = pos;
        if (control.model.IsValidMapPosition(transform) == false)
        {
            pos.x -= h;

            transform.position = pos;
            //control.model.badguys.Add(pos, this);
        }

    }

    // Update is called once per frame


    private void InputControl()
    {

        float h = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            h = -1;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            h = 1;
        }

        if (!Mathf.Approximately(h,0))

        {
            
            Vector3 pos = transform.position;
            pos.x += h;
            transform.position = pos;

            if (control.model.IsValidMapPosition(transform) == false)
            {
                pos.x -=h;

                transform.position = pos;
                control.model.badguys.Add(pos, this);
            }
            else
            {

            }


        }




        }

}
