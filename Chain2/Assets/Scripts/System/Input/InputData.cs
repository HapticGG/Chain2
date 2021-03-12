using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "InputData" , menuName = "SystemData/InputData")]
public class InputData : ScriptableObject
{
    [Header ("The Screen position where the input began")]
    public float startX;
    [Header ("Either the current position where input is occuring OR the last position for input before the finger was lifted")]
    public float lastX;
    [Header ("The total distance between startX and lastX")]
    public float deltaX;
    [Header ("The distance between StartX and lastX Normalized to be between -1 and 1 (0 is neutral)")]
    public float normalizedDelta;
    [Header ("The actual screen distance between left and right side of the screen")]
    public float maxDelta;
    [Header ("An enum stating if the finger is currently tapped or not")]
    public fingerState state;

}

public enum fingerState
{
    down,
    up,
}
