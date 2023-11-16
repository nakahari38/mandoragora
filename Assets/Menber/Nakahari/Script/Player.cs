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

    int apple;
    int orange;
    int pair;

    private AttackForce _attackForce;


    // Start is called before the first frame update
    void Start()
    {
        if(rb2D == null) rb2D = GetComponent<Rigidbody2D>();
        if(_attackForce == null) _attackForce = GetComponent<AttackForce>();
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
    }

    void FlickDirection()
    {
        flickValue_x = endPos.x - startPos.x;
        flickValue_y = endPos.y - startPos.y;
        //Debug.Log("x �t���b�N�ʂ�" + flickValue_x);
        //Debug.Log("y �t���b�N�ʂ�" + flickValue_y);
    }

    void GetDirection()
    {
        FlickDirection();
        Vector2 force = new Vector2(flickValue_x, flickValue_y);
        rb2D.AddForce(force * 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            apple++;
            _attackForce._power += 150;
            Debug.Log("�����S" + apple);
            //Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Orange"))
        {
            orange++;
            _attackForce._power -= 150;
            Debug.Log("�I�����W" + orange);
            //Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Pair"))
        {
            pair++;
            Debug.Log("�i�V" + pair);
            //Destroy(collision.gameObject);
        }
    }
}
