using System.Collections;
using System.Collections.Generic;
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
    List<GameObject> list = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pace = pace + Time.deltaTime;

        if (pace > sense)
        {
            int index = Random.Range(0, list.Count);

            float x = Random.Range(RangeA.position.x, RangeB.position.x);

            float y = Random.Range(RangeA.position.y, RangeB.position.y);

            Instantiate(list[index], new Vector2(x, y), Quaternion.identity);

            pace = 0f;
        }
        
    }
}
