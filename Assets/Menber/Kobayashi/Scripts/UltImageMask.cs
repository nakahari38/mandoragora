using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltImageMask : MonoBehaviour
{
    [SerializeField]
    public Transform parent;
    private ULT _ult;

    [SerializeField]
    private int MultiNum = 20;

    RectMask2D rectMask2D;

    private void Awake()
    {
        rectMask2D = GetComponent<RectMask2D>();
        _ult= parent.GetComponent<ULT>();
    }

    // Update is called once per frame
    void Update()
    {
        rectMask2D.padding = new Vector4(_ult.UltScore * MultiNum, 0f, 0f, 0f);
    }
}
