using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroll : MonoBehaviour
{
    public float speed = 2.0f;
    public float xPos = -10f;
    public LevelGen levelGenerator = null;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    private void Update()
    {
        if (transform.position.x < xPos)
        {
            levelGenerator.DequeuePiece();
            Destroy(gameObject);
        }
    }
}
