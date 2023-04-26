using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float unitsAbovePerfectSpot;
    float arrowTime;

    ArrowStream parentArrowStream;

    public void StartArrow(float timeToLive)
    {
        arrowTime = timeToLive;
        transform.position = new Vector2(transform.position.x, -3.5f + unitsAbovePerfectSpot);
        StartCoroutine(MoveDown());
    }

    private IEnumerator MoveDown()
    {
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 positionToGoTo = new Vector2(transform.position.x, -3.5f - unitsAbovePerfectSpot);
        float time = 0;
        float journeyLength = Vector2.Distance(transform.position, positionToGoTo);

        while(time < arrowTime)
        {
            yield return null;
            transform.position = Vector2.Lerp(startPosition, positionToGoTo, time/arrowTime);
            time += Time.deltaTime;
            //Debug.Log(time/arrowTime);
        }

        StopCoroutine(MoveDown());
    }
}
