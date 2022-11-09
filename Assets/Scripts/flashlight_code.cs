using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight_code : MonoBehaviour
{   //Great code, nice
    // Start is called before the first frame update
    public GameObject ON;
    public GameObject OFF;
    private bool isON;

    void Start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);
        isON = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Debug.Log("Mouse.x" + mouse.x + "Mouse.y" +mouse.y);
        if (Input.GetKeyDown(KeyCode.F)){
            if(isON){
                ON.SetActive(false);
                OFF.SetActive(true);
            }
            if(!isON){
                ON.SetActive(true);
                OFF.SetActive(false);
            }
            isON = !isON;
        }
    }
}
