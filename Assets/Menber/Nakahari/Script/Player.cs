using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector2 _startPos;
    Vector2 _endPos;

    float _flickValue_x;
    float _flickValue_y;

    private Rigidbody2D _rb2D;

    private Catch _catch;

    [SerializeField]
    private float _move;


    // Start is called before the first frame update
    void Start()
    {
        if(_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();
        if(_catch == null) _catch = GetComponent<Catch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GetDirection();
        }

        //Debug.Log(rb2D.velocity.magnitude);
    }

    void FlickDirection()
    {
        _flickValue_x = _endPos.x - _startPos.x;
        _flickValue_y = _endPos.y - _startPos.y;
        //Debug.Log("x フリック量は" + flickValue_x);
        //Debug.Log("y フリック量は" + flickValue_y);
    }

    void GetDirection()
    {
        FlickDirection();
        Vector2 force = new Vector2(_flickValue_x, _flickValue_y);
        _rb2D.AddForce(force * (_move + _catch._speed));
    }
}
