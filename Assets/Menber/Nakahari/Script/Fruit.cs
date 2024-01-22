using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    int _index;

    private Rigidbody2D _rb2D;

    Vector2 _force;

    private System.Action<Fruit> _deadCallback;

    public Vector3 _thisPosition;

    public void Setup(System.Action<Fruit> deadCallback)
    {
        _deadCallback = deadCallback;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ��ʍ��E�̂ǂ���ɏo�����̔���
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();
        if(this.gameObject.transform.position.x <= -1)
        {
            _index = 1;
        }
        else
        {
            _index = -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_thisPosition);
        _rb2D.AddForce(_force);

        if(this.transform.position.x >= 2100 || this.transform.position.x <= -2100)
        {
            _deadCallback?.Invoke(this);
            Destroy(gameObject);
        }
        _thisPosition = this.transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �n�ʂɐG�ꂽ��͂�������
        if (collision.gameObject.CompareTag("Ground"))
        {
            //StartCoroutine(Delete()); // �t���[�c�������Ă���10�b�ŏ����ꍇ�̃R�[�h

            _force = new Vector2(_index*100, 0);  
        }
        // �L�����N�^�[�ɐG�ꂽ��폜����
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CPU1") || collision.gameObject.CompareTag("CPU2") || collision.gameObject.CompareTag("CPU3"))
        {
            _deadCallback?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
