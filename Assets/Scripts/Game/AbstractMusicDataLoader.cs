using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMusicDataLoader
{
    protected List<SimpleMusicData> musicDataList;
    protected string path;

    public AbstractMusicDataLoader(string path){
        this.path = path;
        this.musicDataList = new List<SimpleMusicData>();
    }
    public List<SimpleMusicData> GetMusicDataList()
    {
        Load();
        return musicDataList;
    }
    abstract protected void Load();

}
