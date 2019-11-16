using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Control control;
    public Shape[] shapes;
    public SpaceFighter sf;
    bool isPause = true;
    //private Shape currentShape = null;
    private SpaceFighter currentSF = null;
    private float timer = 0;
    private float stepTime = 2.0f;

    public List<Shape> mList = new List<Shape>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
       
        control = GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update gameManager");
        //if (isPause)
        //{
        //    Debug.Log("pasue game manager");
        //}
        if (isPause) return;

        control.view.TimeUp();
        //if (currentShape == null)
        //{


        //        SpawnShape();
        //        //Fall();

        //}

        timer += Time.deltaTime;
        if (timer > stepTime)
        {
            timer = 0;
            SpawnShape();
            //Debug.Log("0000update gameManager");
            //Fall();
        }

        control.view.UpdateScores(control.model.dh.ToString(),
       control.model.ipg.ToString(),
           control.model.s.ToString(),
       control.model.r.ToString(),
           control.model.b.ToString(),
       control.model.g.ToString(),
           control.model.rgb.ToString());

        if (control.model.CheckWin())
        {
            PauseGame();
            string s = "Congratulations! You Won!  ";


            control.view.ShowOverUI(s, new Color(255, 215, 0));
            isOver = true;
        }


        DestroyDebris();

        //Move();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{


        //    //control.view.space_pause = true;
        //    Debug.Log("您按下了空格键,playstate");
        //    //fsm.PerformTransition(Transition.Play2Pause);

        //    //return;
        //}


    }

    public void StartGame()
    {

        //Instantiate(sf);
        isPause = false;

        Debug.Log("Start gameManager");
        //if (currentShape != null)
        //{
        //    currentShape.Resume();
        //}

        foreach(Shape child in mList)
        {
            if(child != null)
            {
                child.Resume();

            }

        }

        if (currentSF == null)
        {
            currentSF = Instantiate(sf);
        }
        else
        {
            currentSF.Resume();
        }


        //isPause = false;

    }

    public void PauseGame()
    {
        isPause = true;

        foreach (Shape child in mList)
        {
            if (child != null)
            {
                child.Pause();
            }

        }
        //if (currentShape != null)
        //{
        //    currentShape.Pause();
        //}

        if (currentSF != null)
        {
            currentSF.Pause();
        }


    }
    int former = 0;


    void SpawnShape()
    {
        Debug.Log("Spawn shape gameManager");
        int index = Random.Range(0, shapes.Length);
        //currentShape = Instantiate(shapes[index]);
        //currentShape.Init(this, control);
        while(index == former){
            index = Random.Range(0, shapes.Length);
        }



        Shape temp = Instantiate(shapes[index]);
        temp.Init(this, control);
        mList.Add(temp);

        former = index;


    }

    public void Move()
    {

        foreach (Shape s in mList)
        {

            if (s.tag == "Blue" && s.moveLeft == true)
            {
                //Debug.Log("MoveBlue");
                s.MoveLeft();
                //s.Pause();

                //mList.Remove(s);

                //Destroy(s.gameObject);
            }
        }

    }

    public void DestroyDebris()
    {

        int idx = -1;
        foreach(Shape s in mList)
        {

            if (s.tag=="Debris" && s.destroy == true)
            {
                //Debug.Log("DestroyDebris");
                control.model.dh++;
                s.Pause();
                idx = mList.IndexOf(s);
                //mList.Remove(s);

                Destroy(s.gameObject);
            }
        }


        if(idx != -1)
        {
            mList.RemoveAt(idx);
        }
       

    }

    public void ReStart()
    {
        isOver = false;
        Destroy(currentSF.gameObject);
        currentSF = null;
        foreach(Shape s in mList)
        {
            Destroy(s.gameObject);
            //s = null;

        }

        mList = new List<Shape>();

        //control.playState.popup = false;
    }


    bool isOver = false;
    public bool CheckOver()
    {
        if (isOver)
        {
            return true;
        }
        return false;
    }

    public void RecoverOver()
    {
        isOver = true;
    }

    public void FallDown(string tag, int x, int y)
    {

        //if (control.model.isDataUpdate)
        //{

        //}
        if (tag =="Debris")
        {
            if (control.model.CheckDebris())

            {
                PauseGame();
                string s = "Opps! Debris are filled in the storage! ";

                control.view.ShowOverUI(s, new Color(1.0f, 0.64f, 0.0f));
                isOver = true;
                //control.playState.popup = true;
                //control.view.ShowOverUI(s, new Color(255, 140,0));
                //control.updatestate();
                //control.playState.enabled = false;
            }


            if (control.model.CheckFull(x))
            {
                PauseGame();
                string s = "Opps! Ionised particles are not successfully lined in the storage!  ";
                
                control.view.ShowOverUI(s, new Color(0,0,0));
                isOver = true;
                //control.updatestate();
                //control.playState.popup = true;
                //control.playState.enabled = false;
            }

        }
        else
        {
            if (control.model.CheckFull(x))
            {
                PauseGame();
                string s = "Opps! Ionised particles are not successfully lined in the storage!  ";
                control.view.ShowOverUI(s, new Color(0, 0, 0));
                isOver = true;
                //control.updatestate();
                //control.playState.popup = true;
                //control.playState.enabled = false;
            }
        }








        //if(tag == "Debris")
        //{
        //    if (control.model.IsGameOver(tag))
        //    {
        //        PauseGame();
        //        string s = "Opps! Debris are filled in the storage! ";
        //        control.view.ShowOverUI(s);
        //    }
        //}

        //if (tag != "Debris")
        //{
        //    if (control.model.IsGameOver(tag))
        //    {
        //        PauseGame();
        //        string s = "Opps! Ionised particles are not successfully lined in the\nstorage!  ";
        //        control.view.ShowOverUI(s);
        //    }
        //}





        //currentShape = null;

        //foreach (Shape child in mList)
        //{
        //    if (child != null)
        //    {
        //        child = null;
        //    }

        //}
    }
}
