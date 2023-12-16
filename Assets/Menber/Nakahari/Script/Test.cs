using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image uiImage; // UIのImageコンポーネントをアタッチしてください
    public Color yellowColor = Color.yellow;
    public Color whiteColor = Color.white;
    public float blinkInterval = 5f; // 点滅間隔（秒）
    public float blinkDuration = 0.5f; // 点滅の継続時間（秒）

    private void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // 白に変更して0.5秒点滅
            uiImage.color = whiteColor;
            yield return new WaitForSeconds(blinkDuration);

            // 黄色に変更して5秒表示
            uiImage.color = yellowColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
