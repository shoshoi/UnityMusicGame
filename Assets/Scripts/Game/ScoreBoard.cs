using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : SingletonMonoBehaviour<ScoreBoard>{
    private GameObject scoreBoard;
    private Text scoreText;
    private int score;
    private int max_count;
    private int great_count;
    private int good_count;
    private int bad_count;
    private int late_count;
    private int combo = 0;
    private int maxCombo = 0;

	// Use this for initialization
	void Start () {
        SimpleMusicData musicData = GameParameter.Instance().GetSelectMusicData();
        max_count = (musicData.KeyArray == null) ? 0 : musicData.KeyArray.Length;
        scoreBoard = GameObject.Find("ScoreBoard");
        scoreText = scoreBoard.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddScore(Judgement judge){
        switch(judge)
        {
            case Judgement.GREAT:
                great_count++;
                break;
            case Judgement.GOOD:
                good_count++;
                break;
            case Judgement.BAD:
                bad_count++;
                break;
            case Judgement.LATE:
                break;
            default:
                break;
        }
        ComboCount(judge);
        double clearCount = great_count + good_count * 0.8 + bad_count * 0.5;
        score = (int)((double)10000 / max_count * clearCount);
        string text = "SCORE:" + score + "\n" + 
                      "COMBO:" + combo + "\n" +
                      "MAXCOMBO:" + maxCombo;
        scoreText.text = text;
    }
    private void ComboCount(Judgement judge)
    {
        if (judge == Judgement.GREAT || judge == Judgement.GOOD)
        {
            combo++;
            if (combo > maxCombo)
            {
                maxCombo = combo;
            }
        }
        else
        {
            combo = 0;
        }
    }
}
