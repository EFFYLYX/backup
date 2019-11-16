using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public bool right = false;
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
    //    right = true;
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("right");
        right = true;
    }
}
