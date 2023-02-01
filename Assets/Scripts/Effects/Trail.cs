using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Trail : MonoBehaviour
{
    TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        InputManager.OnStartTouch += UpdateGameObjectPosition;
        InputManager.OnEndTouch += TurnOffObject;
    }

    void UpdateGameObjectPosition(Vector2 startPos, float time)
    {
        transform.position = startPos;
        tr.enabled = true;
    }

    void TurnOffObject(Vector2 endPos, float time)
    {
        transform.position = endPos;
        tr.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (tr.enabled)
        {
            Vector2 curPos = InputManager.Instance.PrimaryPosition();
            transform.position = curPos;
        }    
    }
}
