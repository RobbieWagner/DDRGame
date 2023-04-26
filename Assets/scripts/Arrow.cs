using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float unitsAbovePerfectSpot;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, unitsAbovePerfectSpot);
    }
}
