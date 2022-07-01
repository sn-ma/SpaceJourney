using System.Collections.Generic;
using UnityEngine;

public class ExitOnButton : MonoBehaviour
{
    [SerializeField]
    private List<KeyCode> exitButtons;

    void Update()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            foreach (KeyCode key in exitButtons)
            {
                if (Input.GetKeyUp(key))
                {
                    Application.Quit();
                }
            }
        }
    }
}
