using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    int index;

    private Rigidbody2D rb2D;

    Vector2 force;

    private System.Action<Fruit> _deadCallback;
    public void Setup(System.Action<Fruit> deadCallback)
    {
        _deadCallback = deadCallback;
    }

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

        if(this.transform.position.x >= 2100 || this.transform.position.x <= -2100)
        {
            _deadCallback?.Invoke(this);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            force = new Vector2(index*500, 0);  
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CPU1") || collision.gameObject.CompareTag("CPU2") || collision.gameObject.CompareTag("CPU3"))
        {
            _deadCallback?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
