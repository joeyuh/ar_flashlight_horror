using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class flashlight_code : MonoBehaviour
{
    //Great code, nice
    // Start is called before the first frame update
    public GameObject ON;
    public GameObject OFF;
    public GameObject flashlight;
    public GameObject player;

    [Header("Max angle")] public int horizontal = 45;
    public int vertical = 15;

    private bool isON;

    private Vector2 _center = new Vector2(Screen.width / 2f, Screen.height / 2f);

    private Vector3 Angle(Vector3 mouse)
    {
        if (mouse.x < 0) mouse.x = 0;
        if (mouse.y < 0) mouse.y = 0;
        if (mouse.x > Screen.width) mouse.x = Screen.width;
        if (mouse.y > Screen.height) mouse.y = Screen.height;
        mouse.x -= _center.x;
        mouse.y -= _center.y;
        mouse.x /= _center.x;
        mouse.y /= _center.y;
        mouse.x *= Mathf.Deg2Rad * horizontal;
        mouse.y *= Mathf.Deg2Rad * vertical;
        Vector3 p = player.transform.eulerAngles;
        return new Vector3(-Mathf.Rad2Deg * Mathf.Sin(mouse.y) + p.x,
            Mathf.Rad2Deg * Mathf.Sin(mouse.x) + p.y, 0);
    }

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
        flashlight.transform.eulerAngles = Angle(mouse);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isON)
            {
                ON.SetActive(false);
                OFF.SetActive(true);
            }

            if (!isON)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
            }

            isON = !isON;
        }
    }
}