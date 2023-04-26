using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float unitsAbovePerfectSpot;

    public void StartArrow()
    {
        Debug.Log("starting");
        transform.position = new Vector2(transform.position.x, -3.5f + unitsAbovePerfectSpot);
        StartCoroutine(MoveDown());
    }

    private IEnumerator MoveDown()
    {
        Debug.Log("moving");
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 positionToGoTo = new Vector2(transform.position.x, -3.5f - unitsAbovePerfectSpot);
        float startTime = Time.time;
        float journeyLength = Vector2.Distance(transform.position, positionToGoTo);

        while (transform.position.y > positionToGoTo.y)
        {
            yield return null;
            float distanceCovered = (Time.time - startTime);
            float fractionOfJourney = distanceCovered/journeyLength;
            transform.position = Vector2.Lerp(startPosition, positionToGoTo, fractionOfJourney);
        }

        Debug.Log("done");
        StopCoroutine(MoveDown());
    }
}
