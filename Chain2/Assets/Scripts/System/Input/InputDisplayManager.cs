using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputDisplayManager : MonoBehaviour
{
    [Header ("The head of the input slider")]
    public RectTransform slider;

    [Header ("Data to be acted on")]
    public InputData data;
    public Vector2 positions;

    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector2(25, Screen.width -25);
    }

    // Update is called once per frame
    void Update()
    {
        slider.position = new Vector3(Mathf.Lerp(positions.x, positions.y, data.normalizedDelta) , slider.position.y);
    }
}
