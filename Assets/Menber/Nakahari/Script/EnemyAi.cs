using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static LoadCSV;
using static UnityEngine.GraphicsBuffer;

public enum SelectType
{
    player,
    enemy1,
    enemy2,
    apple,
    pear,
    orange
}

public class EnemyAi : MonoBehaviour
{
    public List<LoadCSV.LoveParams> ItemLoves = new List<LoadCSV.LoveParams> ();

    /*public SelectType Select()
    {

        foreach (var loveParams in _loveLists)
        {
            LoveParams copiedParams = new LoveParams
            {
                PlayerLove = loveParams.PlayerLove,
                Enemy1Love = loveParams.Enemy1Love,
                Enemy2Love = loveParams.Enemy2Love,
                AppleLove = loveParams.AppleLove,
                PearLove = loveParams.PearLove,
                OrangeLove = loveParams.OrangeLove
            };

            ItemLoves.Add(copiedParams);
        }

        foreach (var loveParams in ItemLoves)
        {
            Debug.Log("-------------------------------------");
            Debug.Log("PlayerLove: " + loveParams.PlayerLove);
            Debug.Log("Enemy1Love: " + loveParams.Enemy1Love);
            Debug.Log("Enemy2Love: " + loveParams.Enemy2Love);
            Debug.Log("AppleLove: " + loveParams.AppleLove);
            Debug.Log("PearLove: " + loveParams.PearLove);
            Debug.Log("OrangeLove: " + loveParams.OrangeLove);
        }
        var appleLists = FruitGeneration._fruitView.Where(item => item.gameObject.tag.Equals("Apple"))
                            .ToList();
        var appleDistance = appleLists
                                .Select(item => (item.transform.localPosition - target.transform.localposition).distance)
                                .ToList();
        var minIndex = appleDistance.IndexOf(appleDistance.Min());
        var applMinObject = appleLists[minIndex];
        var appleMinDistance = Mathf.Floor(appleDistance[minIndex]);
        ItemLoves[(int)SelectType.apple] += 30 - appleMinDistance;
        return SelectType.player;
    }*/

    // ステータス
    [SerializeField]
    float _move = 5; // 移動

    //State currentState = State.eat;
    //bool stateEnter = true;

    private Catch _catch;

    // ゲージが溜まってから技発動までの時間
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

    Vector2 tracking;

    Vector3 _pos;

    [SerializeField]
    private float _sense;

    private float _pace;

    [SerializeField]
    private GameObject _flowerPot1;
    [SerializeField]
    private GameObject _flowerPot2;

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

        // 一定間隔で狙う相手を変える
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

        // 相手と自身のpositonを計算しその方向に最大速度を制限しながら力を加える
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

    // Colliderの衝突した位置を計算してぶつかった位置にエフェクトをInstantiateする
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
