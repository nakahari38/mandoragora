using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackForce : MonoBehaviour
{
    [SerializeField]
    public float power;
    [SerializeField]
    public float endurance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.GetComponent<Fruit>())
        {
            Rigidbody2D _otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_otherRb2d == null) return;

            Vector2 _directions = (collision.transform.position - this.transform.position).normalized;

            _otherRb2d.AddForce(_directions * power / endurance, ForceMode2D.Impulse);
        }
    }
}
