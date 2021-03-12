using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    [Header ("References")]
    public InputData data;

    //Events
    public delegate void fingerDown();
    public static event fingerDown onFingerDown;

    public delegate void fingerUp();
    public static event fingerUp onFingerUp;

    [Header("Attributes")]
    public fingerState InputState;
    public platform _platform;
    public phase inputPhase;


    //Methods

    private void Start()
    {
        initializeData();
    }


    private void Update()
    {        
        //!!!this is all windows specific code and wont work at all on android!!!
        if(Input.GetMouseButtonDown(0))
        {
            fingerTapped();
        }
        else
        {
            if(Input.GetMouseButton(0))
            {
                //update data while the cursor is down
                data.state = fingerState.down;
                data.lastX = Input.mousePosition.x;
                data.deltaX = data.lastX - data.startX;
                data.normalizedDelta = normalizeDelta(data.deltaX, data.maxDelta);
                data.normalizedDelta = clampDelta(data.normalizedDelta);
            }
            else
            {
                if(Input.GetMouseButtonUp(0))
                {
                    fingerReleased();
                }
            }
        }

    }

    //initialize the data each run
    private void initializeData()
    {
        data.startX = 0;
        data.lastX = 0;
        data.deltaX = 0;
        data.maxDelta = 0;
        data.normalizedDelta = 0.5f;
        data.state = fingerState.up;
        calculateDelta();
    }

    //This method will calculate the max delta for the screen
    private void calculateDelta()
    {
        float screenWidth = Screen.width;
        data.maxDelta = screenWidth / 2;
    }

    //this method is used for normalizing the delta
    private float normalizeDelta(float delta, float maxDelta)
    {
        return (Mathf.Abs(delta) / Mathf.Abs(maxDelta)) * Mathf.Sign(delta) + 0.5f;
    }

    //make sure the delta is clamped to -1,1
    private float clampDelta(float delta)
    {
        float dat = delta;
        if (dat < -1)
            dat = -1;
        if (dat > 1)
            dat = 1;
        return dat;
    }

    //calls the event for first touching the screen
    private void fingerTapped()
    {
        inputPhase = phase.started;
        data.state = fingerState.down;

        //this is temporary and will not work on android
        data.startX = Input.mousePosition.x;

        if(onFingerDown!=null)
        {
            onFingerDown();
        }
    }

    //calls the event for stopping the touch
    private void fingerReleased()
    {
        inputPhase = phase.idle;
        data.state = fingerState.up;

        //this is temporary and will not work on android 
        data.lastX = Input.mousePosition.x;

        if(onFingerUp!=null)
        {
            onFingerUp();
        }
    }

    //call this method to finalize the data
    public void fingerReset()
    {
        data.normalizedDelta = 0.5f;
    }
}

//enums for organization purposes
public enum platform
{
    windows,
    android
}

public enum phase
{
    started,
    inProgress,
    idle
}