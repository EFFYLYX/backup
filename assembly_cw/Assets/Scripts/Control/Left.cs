using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("Left");
    //    left = true;
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Left");
        left = true;
    }
}
