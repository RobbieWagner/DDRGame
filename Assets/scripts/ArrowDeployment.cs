using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDeployment : MonoBehaviour
{
    public bool[] displayLeftUpDownRight;

    public void Deploy(ArrowStream[] arrowStreams, float arrowLifeSpan)
    {
        for(int i = 0; i < displayLeftUpDownRight.Length; i++)
        {
            //if(displayLeftUpDownRight[i]) arrowStreams[i].AddArrow(arrowLifeSpan);
        }
    }
}
