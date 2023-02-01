using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public float minDist = .3f;
    public float maxTime = .8f;

    [Range(0, 1)]
    public float dirThreshold = .9f;

    Vector2 startPos;
    float startTime;

    Vector2 endPos;
    float endTime;

    private void OnEnable()
    {
        InputManager.OnStartTouch += SwipeStart;
        InputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        InputManager.OnStartTouch -= SwipeStart;
        InputManager.OnEndTouch -= SwipeEnd;
    }

    void SwipeStart(Vector2 pos, float time)
    {
        startPos = pos;
        startTime = time;
    }   
    
    void SwipeEnd(Vector2 pos, float time)
    {
        endPos = pos;
        endTime = time;
        CheckSwipe();
    }

    void CheckSwipe()
    {
        if (Vector3.Distance(startPos, endPos) >= minDist && (endTime - startTime) <= maxTime)
        {
            Vector3 dir = endPos - startPos;
            Vector2 dir2D = new Vector2(dir.x, dir.y);
            SwipeDirection(dir2D);
            return;
        }

        //swipe failed do something down here
    }

    void SwipeDirection(Vector2 dir)
    {
        Vector2 dirNormalized = dir.normalized;

        if (Vector2.Dot(Vector2.up, dirNormalized) >= dirThreshold)
        {
            Debug.Log("Swipe Up");
        }

        if (Vector2.Dot(Vector2.down, dirNormalized) >= dirThreshold)
        {
            Debug.Log("Swipe Down");
        }

        if (Vector2.Dot(Vector2.left, dirNormalized) >= dirThreshold)
        {
            Debug.Log("Swipe Left");
        }

        if (Vector2.Dot(Vector2.right, dirNormalized) >= dirThreshold)
        {
            Debug.Log("Swipe Right");
        }
    }    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
