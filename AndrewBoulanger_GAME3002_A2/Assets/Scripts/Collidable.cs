using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable:MonoBehaviour
{
    public delegate void OnCollectPointsDelegate(int points);
    public static OnCollectPointsDelegate CollectPointsDelegate;

    [SerializeField] 
    private int points;

    void RaiseScore()
    {
        CollectPointsDelegate(points);
    }

    void OnCollisionEnter(Collision collision)
    {
        RaiseScore();
    }
}