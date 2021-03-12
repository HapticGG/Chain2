using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputDisplayManager : MonoBehaviour
{
    public RectTransform slider;
    public InputData data;
    public Vector2 positions;
    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector2(-Screen.width / 2, Screen.width / 2);
    }

    // Update is called once per frame
    void Update()
    {
        slider.position = new Vector3(Mathf.Lerp(positions.x, positions.y, data.normalizedDelta) , slider.position.y);
    }
}
