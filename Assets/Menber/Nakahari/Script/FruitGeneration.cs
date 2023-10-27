using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FruitGeneration: MonoBehaviour
{
    Vector2 Spawn;
    [SerializeField]
    private Transform RangeA;
    [SerializeField]
    private Transform RangeB;

    [SerializeField]
    private float sense;

    private float pace;

    [SerializeField]
    List<GameObject> _fruitList = new List<GameObject>();

    [SerializeField]
    List<Fruit> _fruitView = new List<Fruit>();


    // Update is called once per frame
    void Update()
    {
        pace = pace + Time.deltaTime;

        if (pace > sense)
        {
            int index = Random.Range(0, _fruitList.Count);

            float x = Random.Range(RangeA.position.x, RangeB.position.x);

            float y = Random.Range(RangeA.position.y, RangeB.position.y);

            var fruit = Instantiate(_fruitList[index], new Vector2(x, y), Quaternion.identity);

            var fruitView = fruit.GetComponent<Fruit>();

            fruitView.Setup(DestroyFrutes);

            _fruitView.Add(fruitView);
            pace = 0f;
        }
        
    }

    private void DestroyFrutes(Fruit fruitsView)
    {
        _fruitView.Remove(fruitsView);
    }
}
