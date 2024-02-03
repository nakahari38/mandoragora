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
    public List<LoadCSV.LoveParams> ItemLoves = new List<LoadCSV.LoveParams>();

    public SelectType Select()
    {
        // ItemLoves の初期化
        ItemLoves.Clear();

        // フルーツごとに処理をまとめたメソッドを呼び出す
        UpdateLoveByFruitTag("Apple", SelectType.apple);
        UpdateLoveByFruitTag("Pear", SelectType.pear);
        UpdateLoveByFruitTag("Orange", SelectType.orange);

        // Calculate the sum of the specific property (e.g., AppleLove, PearLove, OrangeLove)
        var sum = ItemLoves.Sum(loveParams => loveParams.AppleLove + loveParams.PearLove + loveParams.OrangeLove);

        var rnd = Random.Range(0, sum);
        var selectIndex = 0;
        foreach (var (loves, index) in ItemLoves.Select((loves, index) => (loves.AppleLove + loves.PearLove + loves.OrangeLove, index)))
        {
            if (rnd < loves)
            {
                selectIndex = index;
                break;
            }
        }

        return (SelectType)selectIndex;
    }

    // タグごとに果物の情報とポジションを更新するメソッド
    private Vector3 UpdateLoveByFruitTag(string fruitTag, SelectType selectType)
    {
        var fruitLists = FruitGeneration._fruitView
            .Where(item => item.gameObject.tag.Equals(fruitTag))
            .ToList();

        Vector3 fruitPosition = Vector3.zero; // 追加: フルーツの位置を格納する変数

        if (fruitLists.Any()) // リストが空でないか確認
        {
            var minObject = fruitLists
                .OrderBy(item => (item.transform.localPosition - this.transform.localPosition).magnitude)
                .FirstOrDefault();

            if (minObject != null)
            {
                fruitPosition = minObject.transform.position; // フルーツの位置を取得

                // Ensure ItemLoves has enough elements
                while (ItemLoves.Count <= (int)selectType)
                {
                    ItemLoves.Add(new LoveParams());
                }

                // Update love based on fruit type
                switch (selectType)
                {
                    case SelectType.apple:
                        ItemLoves[(int)selectType].AppleLove += 30 + (int)Mathf.Floor(Vector3.Distance(fruitPosition, this.transform.localPosition));
                        break;
                    case SelectType.pear:
                        ItemLoves[(int)selectType].PearLove += 30 + (int)Mathf.Floor(Vector3.Distance(fruitPosition, this.transform.localPosition));
                        break;
                    case SelectType.orange:
                        ItemLoves[(int)selectType].OrangeLove += 30 + (int)Mathf.Floor(Vector3.Distance(fruitPosition, this.transform.localPosition));
                        break;
                }
            }
        }

        return fruitPosition; // フルーツの位置を返す
    }



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
        if (_attackForce == null) _attackForce = GetComponent<AttackForce>();

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
            foreach(var item in ItemLoves)
            {
                Debug.Log(this.gameObject.name + "プレイヤー:" + item.PlayerLove);
                Debug.Log(this.gameObject.name + "エネミー１:" + item.Enemy1Love);
                Debug.Log(this.gameObject.name + "エネミー２:" + item.Enemy2Love);
                Debug.Log(this.gameObject.name + "リンゴ:" + item.AppleLove);
                Debug.Log(this.gameObject.name + "ナシ:" + item.PearLove);
                Debug.Log(this.gameObject.name + "オレンジ:" + item.OrangeLove);
            }
            Debug.Log(Select());
            switch(Select())
            {
                case SelectType.player:
                    _pos = _player.position;
                    break;
                case SelectType.enemy1:
                    _pos = _cpu1.position;
                    break; 
                case SelectType.enemy2:
                    _pos = _cpu2.position;
                    break;
                case SelectType.apple:
                    _pos = UpdateLoveByFruitTag("Apple", Select());
                    break;
                case SelectType.pear:
                    _pos = UpdateLoveByFruitTag("Pear", Select());
                    break;
                case SelectType.orange:
                    _pos = UpdateLoveByFruitTag("Orange", Select());
                    break;
            }
            _pace = 0f;
        }

        // 相手と自身のpositonを計算しその方向に最大速度を制限しながら力を加える
        tracking = _pos - this.transform.position;
        if (_rb2D.velocity.magnitude <= _catch._aiSpeed)
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
