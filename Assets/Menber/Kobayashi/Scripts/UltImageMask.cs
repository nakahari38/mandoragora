using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltImageMask : MonoBehaviour
{
    [SerializeField]
    public Transform parent;
    private ULT _ult;

    [SerializeField]
    private int MultiNum = 20;

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        _ult= parent.GetComponent<ULT>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, _ult.UltScore * MultiNum);
    }
}
