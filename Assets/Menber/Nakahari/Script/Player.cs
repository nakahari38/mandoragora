using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector2 startPos;
    Vector2 endPos;

    float flickValue_x;
    float flickValue_y;

    private Rigidbody2D rb2D;

    private Catch _catch;

    [SerializeField]
    private float move;


    // Start is called before the first frame update
    void Start()
    {
        if(rb2D == null) rb2D = GetComponent<Rigidbody2D>();
        if(_catch == null) _catch = GetComponent<Catch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GetDirection();
        }

        //Debug.Log(rb2D.velocity.magnitude);
    }

    void FlickDirection()
    {
        flickValue_x = endPos.x - startPos.x;
        flickValue_y = endPos.y - startPos.y;
        //Debug.Log("x フリック量は" + flickValue_x);
        //Debug.Log("y フリック量は" + flickValue_y);
    }

    void GetDirection()
    {
        FlickDirection();
        Vector2 force = new Vector2(flickValue_x, flickValue_y);
        rb2D.AddForce(force * (move + _catch.speed));
    }
}
