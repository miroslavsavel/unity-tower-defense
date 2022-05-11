using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();    //waypoints that create our path
    //public GameObject Enemy; //dont need to import it, because this script is attached to the enemy object
    [SerializeField] float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start here");
        StartCoroutine(FollowPath());        //similar to invoke repeating
        //InvokeRepeating("PrintWaypointName", 0, 1f);
        //Debug.Log("Finishing start");
    }

    IEnumerator FollowPath()
    {   
        /* 
         * This coroutine will loop through list and delay its print
         * */
        foreach(Waypoint waypoint in path)
        {
            //Debug.Log(waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);      //we want delay, yield mean give up control and come back after 1second
        }
    }
}
