using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbData : MonoBehaviour
{
    public orbState orbState;
}

public enum orbState
{
    shootOrb,
    deployed,
    idle,
}
