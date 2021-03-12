using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbAim : MonoBehaviour
{
    public InputData _input;
    public orbData _orbData;
    public GameObject aimParticleSystem;
    public Rigidbody rb;
    public static Vector2 maxRot = new Vector2(-30, 30);
    public float shootForce = 10f;
    public GameObject smokePuff;
    // Start is called before the first frame update
    void Start()
    {
        //subscribe to the input event for finger releasing
        InputProcessor.onFingerUp += InputProcessor_onFingerUp;
        rb = GetComponent<Rigidbody>();
    }

    //the finger was released so process it
    private void InputProcessor_onFingerUp()
    {
        if(_orbData.orbState == orbState.shootOrb)
        {
            _orbData.orbState = orbState.deployed;
            rb.useGravity = true;
            rb.AddForce(-transform.forward * shootForce * Time.deltaTime * 2);
            GameObject smoke = Instantiate(smokePuff, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.state == fingerState.down && _orbData.orbState == orbState.shootOrb)
        {
            transform.rotation = Quaternion.Euler(-2.7f, Mathf.Lerp(maxRot.x, maxRot.y, _input.normalizedDelta), 0);
            aimParticleSystem.SetActive(true);
        }
        else
        {
            aimParticleSystem.SetActive(false);
        }
    }
}
