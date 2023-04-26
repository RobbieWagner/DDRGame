using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MusicArrowKeyInput : MonoBehaviour
{

    enum ArrowKeyConditions
    {
        LeftInactive,
        UpInactive,
        DownInactive,
        RightInactive,
        LeftActive,
        UpActive,
        DownActive,
        RightActive

    }

    [SerializeField] private Image[] arrowKeys;
    [SerializeField] private Color[] arrowKeyColors;

    private bool[] isKeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        isKeyPressed = new bool[] {false, false, false, false};

        for(int i = 0; i < arrowKeys.Length; i++)
        {
            arrowKeys[i].color = arrowKeyColors[i];
            isKeyPressed[i] = false;
        }
    }

    public void OnLeftArrow(InputAction.CallbackContext context)
    {
        if (context.started && !isKeyPressed[0])
        {
            ChangeArrowColor(arrowKeys[0], arrowKeyColors[(int) ArrowKeyConditions.LeftActive]);
            isKeyPressed[0] = true;
        }
        else if (context.canceled)
        {
            ChangeArrowColor(arrowKeys[0], arrowKeyColors[(int) ArrowKeyConditions.LeftInactive]);
            isKeyPressed[0] = false;
        }
    }
    
    public void OnUpArrow(InputAction.CallbackContext context)
    {
        if (context.started && !isKeyPressed[1])
        {
            ChangeArrowColor(arrowKeys[1], arrowKeyColors[(int) ArrowKeyConditions.UpActive]);
            isKeyPressed[1] = true;
        }
        else if (context.canceled)
        {
            ChangeArrowColor(arrowKeys[1], arrowKeyColors[(int) ArrowKeyConditions.UpInactive]);
            isKeyPressed[1] = false;
        }
    }

    public void OnDownArrow(InputAction.CallbackContext context)
    {
        if (context.started && !isKeyPressed[2])
        {
            ChangeArrowColor(arrowKeys[2], arrowKeyColors[(int) ArrowKeyConditions.DownActive]);
            isKeyPressed[2] = true;
        }
        else if (context.canceled)
        {
            ChangeArrowColor(arrowKeys[2], arrowKeyColors[(int) ArrowKeyConditions.DownInactive]);
            isKeyPressed[2] = false;
        }
    }

    public void OnRightArrow(InputAction.CallbackContext context)
    {
        if (context.started && !isKeyPressed[3])
        {
            ChangeArrowColor(arrowKeys[3], arrowKeyColors[(int) ArrowKeyConditions.RightActive]);
            isKeyPressed[3] = true;
        }
        else if (context.canceled)
        {
            ChangeArrowColor(arrowKeys[3], arrowKeyColors[(int) ArrowKeyConditions.RightInactive]);
            isKeyPressed[3] = false;
        }
    }


    private void ChangeArrowColor(Image arrowKey, Color color) { arrowKey.color = color;}
}
