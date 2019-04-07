using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameParameter
{
    /* Singletonクラス */
    private static GameParameter _singleInstance = new GameParameter();

    public List<SimpleMusicData> musicDatas; // 楽曲データの一覧
    public int selectMusicDataId;            // 選択中の楽曲のid
    public LocalResources localResources;

    public static GameParameter Instance()
    {
        return _singleInstance;
    }
    private GameParameter()
    {
        AbstractMusicDataLoader musicDataLoader;
        if(GameObject.Find("LocalResources") == null)
        {
            musicDataLoader = new MusicDataResourcesLoader("music/list");
        }
        else
        {
            Debug.Log("LocalResources");
            musicDataLoader = new MusicDataFoldersLoader(1);
        }
            
        musicDatas = musicDataLoader.GetMusicDataList();
        selectMusicDataId = 1;
    }
    public SimpleMusicData GetSelectMusicData()
    {
        return musicDatas[selectMusicDataId - 1];
    }
    public SimpleMusicData GetMusicData(int id)
    {
        return musicDatas[id - 1];
    }
    public void SetLocalResources(LocalResources localResources)
    {
        this.localResources = localResources;
    }
}