using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    // オブジェクト格納変数
    public GameObject scoreBord;
    public Text text;
    public AudioManager audioManager;

    void Start()
    {
        // 楽曲データを読み込む
        GameParameter gameParameter = GameParameter.Instance();
        SimpleMusicData musicData = gameParameter.GetSelectMusicData();
        audioManager = AudioManager.Instance;

        // オーディオソースの準備
        audioManager.SetClip(musicData.GetAudioClip());

        // 楽曲を再生（ゲーム開始）する。
        audioManager.Play();
    }
}
