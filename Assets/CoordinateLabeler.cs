using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
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
