using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]     //execute also in edit mode and also in play mode
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;  //switch off coordinates by default
        waypoint = GetComponentInParent<Waypoint>();       //waypoint is in the parent not in the nested prefabs
        DisplayCoordinates(); //also in play mode
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)      //run only in edit mode
        {
            //do something
            DisplayCoordinates();       // do not change coordinates of object  when moving them in game mode
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();

    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();          //set current state to opposite of current active state
        }
    }

    void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);      //z because we are working in 3D coordinate system
        //current coordinate of our block
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
