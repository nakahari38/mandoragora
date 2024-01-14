using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class FruitGeneration: MonoBehaviour
{
    Vector2 Spawn;
    [SerializeField]
    private Transform _rangeA;
    [SerializeField]
    private Transform _rangeB;

    [SerializeField]
    private float _sense;

    private float _pace;

    [SerializeField]
    List<GameObject> _fruitList = new List<GameObject>();

    [SerializeField]
    public List<Fruit> _fruitView = new List<Fruit>();

    [SerializeField]
    Player _player;
    [SerializeField]
    EnemyAi _enemyAi;
    [SerializeField]
    CountDown _countDown;

    // Update is called once per frame
    void Update()
    {
        if (_countDown._stop) return;
        _pace = _pace + Time.deltaTime;

        if (_pace > _sense)
        {
            int index = Random.Range(0, _fruitList.Count);

            float x = Random.Range(_rangeA.position.x, _rangeB.position.x);

            float y = Random.Range(_rangeA.position.y, _rangeB.position.y);

            var fruit = Instantiate(_fruitList[index], new Vector2(x, y), Quaternion.identity);

            var fruitView = fruit.GetComponent<Fruit>();

            fruitView.Setup(DestroyFrutes);

            _fruitView.Add(fruitView);
            _pace = 0f;
        }
        
    }

    private void DestroyFrutes(Fruit fruitsView)
    {
        _fruitView.Remove(fruitsView);
    }
}
