/*
 * By Alex Dzius
 * Last Edited: 4/2/20
 * Desc: This will follow a game object selected by the game designer
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Tooltip("Set between 0 and 1, where 0 doesnt move and 1 teleports to the target")]
    float t = 0.5f;
    [SerializeField, Tooltip("Select the game object for the camera to track")]
    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Target != null)
        {
            // find target position
            Vector3 newPos = Target.transform.position;
            // maintain z value of camera
            newPos.z = transform.position.z;
            // move camera with linear interpolation
            transform.position = Vector3.Lerp(transform.position, newPos, t);
        }
    }
}
