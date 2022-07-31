using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    //using properties - similar to getter method, but similar to variable
    //use property when nothing change
    public bool IsPlaceable { get { return isPlaceable; } }

    //getter method
    /*public bool GetIsPlaceable()
    {
        return isPlaceable;
    }*/



    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            //Debug.Log(transform.name);
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
        
    }
}
