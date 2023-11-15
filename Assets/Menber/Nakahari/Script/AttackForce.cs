using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackForce : MonoBehaviour
{
    public GameObject _player;

    [SerializeField]
    public float _forcePower;
    [SerializeField]
    public float _forceHeight;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (!this.gameObject)
        {
            Rigidbody2D otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (!otherRb2d) return;
            Vector2 toVec = GetAngleVec(_player, collision.gameObject);
            toVec = toVec + new Vector2(0, _forceHeight);
            otherRb2d.AddForce(toVec * _forcePower, ForceMode2D.Impulse);

        }

    }

    Vector2 GetAngleVec(GameObject _from, GameObject _to)
    {
        Vector2 fromVec = new Vector2(_from.transform.position.x, _from.transform.position.y);
        Vector2 toVec = new Vector2(_to.transform.position.x, _to.transform.position.y);

        return Vector3.Normalize(toVec - fromVec);
    }
}
