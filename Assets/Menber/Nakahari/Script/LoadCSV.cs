using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadCSV : MonoBehaviour
{
    public enum LoveType
    {
        PlayerLove,
        Enemy1Love,
        Enemy2Love,
        AppleLove,
        PearLove,
        OrangeLove,
    }
    public class LoveParams
    {
        public int PlayerLove;
        public int Enemy1Love;
        public int Enemy2Love;
        public int AppleLove;
        public int PearLove;
        public int OrangeLove;
    }

    public static readonly List<LoveParams> _loveLists = new List<LoveParams>();

    // Start is called before the first frame update
    private void Awake()
    {
        var csvTextAsset = Resources.Load<TextAsset>($"EnemyWeight");
        var csvText = csvTextAsset.text.Replace("\r\n", "\n").Replace("\r", "\n");
        var csvEnemyTexts = csvText.Split('\n').ToList()
                                   .Where(txt => !string.IsNullOrWhiteSpace(txt))
                                   .ToList();
        foreach (var (enemyText, index) in csvEnemyTexts.Select((enemyText, index) => (enemyText, index)))
        {
            var loveParam = new LoveParams();
            var paramDatas = enemyText.Split(',').ToList().Select(int.Parse).ToList();
            loveParam.PlayerLove = paramDatas[(int)LoveType.PlayerLove];
            loveParam.Enemy1Love = paramDatas[(int)LoveType.Enemy1Love];
            loveParam.Enemy2Love = paramDatas[(int)LoveType.Enemy2Love];
            loveParam.AppleLove = paramDatas[(int)LoveType.AppleLove];
            loveParam.PearLove = paramDatas[(int)LoveType.PearLove];
            loveParam.OrangeLove = paramDatas[(int)LoveType.OrangeLove];
            _loveLists.Add(loveParam);
        }

        //_loveLists[0];
        /*foreach (var loveList in _loveLists)
        {
            Debug.Log("-------------------------------------");
            Debug.Log(loveList.PlayerLove);
            Debug.Log(loveList.Enemy1Love);
            Debug.Log(loveList.Enemy2Love);
            Debug.Log(loveList.AppleLove);
            Debug.Log(loveList.PearLove);
            Debug.Log(loveList.OrangeLove);
        }*/
    }
}
