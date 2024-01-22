using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // �X�e�[�^�X
    [SerializeField]
    float _move = 5; // �ړ�

    //State currentState = State.eat;
    //bool stateEnter = true;

    private Catch _catch;

    // �Q�[�W�����܂��Ă���Z�����܂ł̎���
    [SerializeField]
    float _spaceTime;

    private Rigidbody2D _rb2D;

    public Vector3 _firstPos;
    public Quaternion _firstRot;

    [SerializeField]
    Transform _player;
    [SerializeField]
    Transform _cpu1;
    [SerializeField]
    Transform _cpu2;
    [SerializeField]
    Transform _cpu3;

    public int random;

    AttackForce _attackForce;

    [SerializeField]
    CountDown _countDown;

    [SerializeField]
    GameObject _effect;

    Vector2 _hitPos;

    //[SerializeField]
    //int times;
    //
    //[SerializeField]
    //int _count;

    Vector2 tracking;

    Vector3 _pos;

    [SerializeField]
    private float _sense;

    private float _pace;

    [SerializeField]
    private GameObject _flowerPot1;
    [SerializeField]
    private GameObject _flowerPot2;

    // �ȉ��͉��u��

    // float skilGage = 0;



    //private float rotationSpeed = 300.0f;


    private void Start()
    {
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();

        if (_catch == null) _catch = GetComponent<Catch>();
        if(_attackForce == null) _attackForce = GetComponent<AttackForce>();

        _firstPos = this.transform.position;
        _firstRot = this.transform.rotation;
    }

    private void Update()
    {
        if (_countDown._stop) return;
        _pace = _pace + Time.deltaTime;

        // ���Ԋu�ő_�������ς���
        if (_pace > _sense)
        {
            int _random = Random.Range(1, 4);
            switch (_random)
            {
                case 1:
                    _pos = _player.position;
                    break;
                case 2:
                    if (this.gameObject.CompareTag("CPU1")) return;
                    _pos = _cpu1.position;
                    break;
                case 3:
                    if (this.gameObject.CompareTag("CPU2")) return;
                    _pos = _cpu2.position;
                    break;
                case 4:
                    if (this.gameObject.CompareTag("CPU3")) return;
                    _pos = _cpu3.position;
                    break;

            }
            _pace = 0f;
        }

        // ����Ǝ��g��positon���v�Z�����̕����ɍő呬�x�𐧌����Ȃ���͂�������
        tracking = _pos - this.transform.position;
        if(_rb2D.velocity.magnitude <= _catch._aiSpeed)
        {
            _rb2D.AddForce(tracking * _move, ForceMode2D.Force);
        }

        switch (_attackForce._count)
        {
            case 1:
                _flowerPot1.SetActive(false);
                _flowerPot2.SetActive(true);
                break;
            case 2:
                _flowerPot2.SetActive(false);
                break;
        }

        //Debug.Log(rb2D.velocity.magnitude);
    }

    // Collider�̏Փ˂����ʒu���v�Z���ĂԂ������ʒu�ɃG�t�F�N�g��Instantiate����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CPU1") || collision.gameObject.CompareTag("CPU2") || collision.gameObject.CompareTag("CPU3"))
        {
            foreach (ContactPoint2D hitPoint in collision.contacts)
            {
                _hitPos = hitPoint.point;
            }
            Instantiate(_effect, new Vector2(_hitPos.x, _hitPos.y), Quaternion.identity);
        }
    }
}
