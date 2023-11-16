using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackForce : MonoBehaviour
{
    [SerializeField]
    public float _power;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.GetComponent<Fruit>())
        {
            Rigidbody2D _otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_otherRb2d == null) return;

            Vector2 v = (collision.transform.position - this.transform.position).normalized;

            _otherRb2d.AddForce(v * _power, ForceMode2D.Impulse);
        }
    }
}
