using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOrientation : MonoBehaviour
{
    public Canvas Portrait;
    public Canvas Landscape;
    // Start is called before the first frame update
    void Start()
    {
        Portrait.enabled = true;
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScreenOrient();
    }

    public void ChangeScreenOrient()
    {
        if (Screen.orientation == UnityEngine.ScreenOrientation.LandscapeLeft)
        {
            {
                Portrait.enabled = false;
                Landscape.enabled = true;
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
            }
        }
        if (Screen.orientation == UnityEngine.ScreenOrientation.LandscapeRight)
        {
            {
                Portrait.enabled = false;
                Landscape.enabled = true;
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeRight;
            }
        }
        if (Screen.orientation == UnityEngine.ScreenOrientation.Portrait)
        {
            {
                Portrait.enabled = true;
                Landscape.enabled = false;
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
            }
        }
    }
}
