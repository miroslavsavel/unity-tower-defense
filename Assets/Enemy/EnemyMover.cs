using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();    //waypoints that create our path
    //public GameObject Enemy; //dont need to import it, because this script is attached to the enemy object
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        ReturnToStart();
        //Debug.Log("Start here");
        StartCoroutine(FollowPath());        //similar to invoke repeating
        //InvokeRepeating("PrintWaypointName", 0, 1f);
        //Debug.Log("Finishing start");
    }

    /*
     * Find all objects with tag "path" in the game and put them into the list of waypoints
     */
    void FindPath()
    {
        //When we find the path we have to clear the previous path, because path can be longer and longer
        path.Clear();

        //this isn't good approach because we cant guarantee they are in specific order!!!
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        //list is slighty different from array https://www.c-sharpcorner.com/article/difference-between-array-and-arraylist-in-c-sharp/
        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());    //add every object from waypoints into the path LIST
        }
    }

    /*
     *Move enemy to the first waypoint
     **/
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }


    IEnumerator FollowPath()
    {   
        /* 
         * This coroutine will loop through list and delay its print
         * */
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;
            //Debug.Log(waypoint.name);
            //transform.position = waypoint.transform.position;
            //yield return new WaitForSeconds(waitTime);      //we want delay, yield mean give up control and come back after 1second

            //point the enemy towards the right way of movement
            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                //we are going to yield back to the update function until the end of the frame has been completed
                //and the we will jump back to our coroutine which will continue our while loop and go through our lines
                yield return new WaitForEndOfFrame();
            }
            //then we will go to the next waypoint
        }
        //after enemy reach the end we destroy the game object with negative consequences for player
        Destroy(gameObject);
    }
}
