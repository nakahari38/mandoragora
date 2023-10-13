using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    int index;

    private Rigidbody2D rb2D;

    Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        if (rb2D == null) rb2D = GetComponent<Rigidbody2D>();
        if(this.gameObject.transform.position.x <= -1)
        {
            index = 1;
        }
        else
        {
            index = -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(index);
        rb2D.AddForce(force);

        if(this.transform.position.x >= 10 || this.transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            force = new Vector2(index, 0);  
        }
    }
}
