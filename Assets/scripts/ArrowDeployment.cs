using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDeployment : MonoBehaviour
{
    public bool[] displayLeftUpDownRight;
    public ArrowStream[] arrowStreams;

    public void Deploy()
    {
        for(int i = 0; i < displayLeftUpDownRight.Length; i++)
        {
            if(displayLeftUpDownRight[i]) arrowStreams[i].AddArrow();
        }
    }
}
