using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFighter : MonoBehaviour
{

    Rigidbody2D rigidbody;
    Control control;
    bool isPause = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
       
       
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

        if (isPause)
        {
            return;
        }

        //Control();
         InputControl();
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    Debug.Log("game over");
    //}


    public void Pause()
    {
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
    }


    //private void Control()
    //{
    //    float h = 0;
    //    string check = null;
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        h = -0.3f;
    //        check = "h";
    //        rigidbody.AddExplosionForce(1500.0f, Vector3.zero, 5.0f);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        h = 0.3f;
    //        check = "h";
    //    }


    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        h = -0.3f;
    //        check = "v";
    //    }
    //    else if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        h = 0.3f;
    //        check = "v";
    //    }

    //    // rb.AddForce (new Vector3(0.0f, 10.0f, 0.0f));
    //}

    private void InputControl()
    {

        float h = 0;
        string check = null;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            h = -0.3f;
            check = "h";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            h = 0.3f;
            check = "h";
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            h = -0.3f;
            check = "v";
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            h = 0.3f;
            check = "v";
        }



        if (!Mathf.Approximately(h, 0) && check=="h")

        {

            Vector3 pos = transform.position;
            pos.x += h;
            transform.position = pos;

            if (pos.x > 1.7)
            {
                pos.x = 1.7f;
            }
            if (pos.x < -1.7)
            {
                pos.x = -1.7f;
            }

            if (pos.y <0.25)
            {
                pos.y = 0.25f;
            }

            if (pos.y > 1.75)
            {
                pos.y = 1.75f;

            }
            if (!(transform.position.x >= -1.7 && transform.position.x <= 1.7 && transform.position.y >= 0.25 && transform.position.y <= 1.75))
            {

                    //pos.x -= h;

                    transform.position = pos;
                    //control.model.badguys.Add(pos, this);

            }

            //h = 0;

            //if (control.model.IsValidMapPosition(transform) == false)
            //{
            //    pos.x -= h;

            //    transform.position = pos;
            //    //control.model.badguys.Add(pos, this);
            //}



        }


        if (!Mathf.Approximately(h, 0) && check=="v")

        {

            Vector3 pos = transform.position;
            pos.y += h;
            transform.position = pos;

            if (pos.x > 1.7)
            {
                pos.x = 1.7f;
            }
            if (pos.x < -1.7)
            {
                pos.x = -1.7f;
            }

            if (pos.y < 0.25)
            {
                pos.y = 0.25f;
            }

            if (pos.y > 1.75)
            {
                pos.y = 1.75f;

            }
            if (!(transform.position.x >= -1.7 && transform.position.x <= 1.7 && transform.position.y >= 0.25 && transform.position.y <= 1.75))
            {

                //pos.y -= h;

                transform.position = pos;
                //control.model.badguys.Add(pos, this);

            }

            //h = 0;

            //if (control.model.IsValidMapPosition(transform) == false)
            //{
            //    pos.x -= h;

            //    transform.position = pos;
            //    //control.model.badguys.Add(pos, this);
            //}



        }


    }

}
