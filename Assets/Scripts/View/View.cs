using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{


    Text dh ;
    Text ipg ;
   Text s ;

    Text r ;
    Text b ;
    Text g;
    Text rgb ;

    Text overText;

    public bool leftMouse = false;
    public bool space_pause = true;
    public bool space_play = false;
    private RectTransform logoName;
    private RectTransform menuUI;

    public GameObject overUI;
    private GameObject t;
    public GameObject text_timer;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void UpdateScores(string DH, string IPG, string S, string R, string B, string G, string RGB)
    {
        dh.text = DH;
        ipg.text = IPG;
        s.text = S;
        r.text = R;
        b.text = B;
        g.text = G;
        rgb.text = RGB;
    }
    //private void OnMouseDown()
    //{
    //    Input.GetMouseButton(0)
    //}

    private void Awake()
    {
        overText = transform.Find("Canvas/PopUp/Image/Text").GetComponent<Text>();
        overUI = transform.Find("Canvas/PopUp").gameObject;


        t = transform.Find("Canvas/Text").gameObject;
       text_timer = transform.Find("Canvas/TopText/T/Text").gameObject;
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;

        dh = transform.Find("Canvas/TopText/DH/Text").GetComponent<Text>();
        ipg = transform.Find("Canvas/TopText/IPG/Text").GetComponent<Text>();
        s = transform.Find("Canvas/TopText/S/Text").GetComponent<Text>();

        r = transform.Find("Canvas/BottomText/R/Text").GetComponent<Text>();

        b  = transform.Find("Canvas/BottomText/B/Text").GetComponent<Text>();
        g= transform.Find("Canvas/BottomText/G/Text").GetComponent<Text>();
        rgb = transform.Find("Canvas/BottomText/RGB/Text").GetComponent<Text>();


    }


    // Update is called once per frame
    void Update()
    {
        //t.GetComponent<Text>().text = "999";
        //score++;

        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("Left Mouse Button Down");
        //    t.GetComponent<Text>().text = "01:01";

        //}//if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("Left Mouse Button Down");
        //}
        //TimeStart();

        }

    public void ShowMenu()
    {
        menuUI.gameObject.SetActive(true);
        t.GetComponent<Text>().text = "Start State";
        //score++;
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("Left Mouse Button Down");
        //    t.GetComponent<Text>().text =score.ToString();
        //    score++;
        //    //t.text = "01:01";



        //}
    }
    public void HideMenu()
    {
        menuUI.gameObject.SetActive(false);
       
    }


    public void Play()
    {
        //while(true){
        //t.GetComponent<Text>().text = score.ToString();
        //score++;

        t.GetComponent<Text>().text = "Play State";
        space_pause = false;

        
        //leftMouse = true;
        //space =false;
        ////}



        //if (Input.GetMouseButton(0))
        //{
        //Debug.Log("Left Mouse Button Down");
        //t.GetComponent<Text>().text = "01:01";
        ////t.text = "01:01";



    }

    public void Pause()
    {
        t.GetComponent<Text>().text = "Pause State";
        space_play = true;
        //space = true;
    }


    private float seconds = 0.0f;
    private float minutes = 0.0f;
    private float hours = 0.0f;
    //private float timer = 0;

    public void TimeRestart()
    {
        seconds = 0.0f;
 minutes = 0.0f;
 hours = 0.0f;
}
    public void TimeUp()
    {
        seconds += Time.deltaTime;
        if (seconds > 60)
        {
            minutes += 1;
            seconds = 0;
        }
        if (minutes > 60){
            hours += 1;
            minutes = 0;
        }
        string min = minutes.ToString();
        string sec = seconds.ToString();

        if(minutes < 10)
        {
            min = "0" + min;
        }

        sec = sec.Split('.')[0];
        if(seconds < 10)
        {
            sec = "0" + sec;
        }


        text_timer.GetComponent<Text>().text = min+":"+sec;

        //print("Hours: " + hours + " " + "Minutes: " + minutes + " " + "Seconds" + seconds);
    }

    public void ShowOverUI(string s, Color color)
    {
        overUI.SetActive(true);

        overText.text = s;
        overText.color = color;


    }

   public bool ShowOver()
    {
        if (overUI.activeSelf)
        {
            return true;
        }
        return false;
    }


    public void HideOverUI()
    {
        overUI.SetActive(false);
    }

}
