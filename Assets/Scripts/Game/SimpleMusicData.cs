using UnityEngine;
using UnityEngine.UI;

public class SimpleMusicData
{
    // ファイル情報
    private int id;
    private string path = "";

    //曲情報
    private MusicInf inf;

    // 譜面情報
    private int bpm;
    private double[] timingArray;
    private int[] keyArray;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Path
    {
        get { return path; }
        set { path = value; }
    }
    public MusicInf Inf
    {
        get { return inf; }
        set { inf = value; }
    }
    public int Bpm
    {
        get { return bpm; }
        set { bpm = value; }
    }
    public double[] TimingArray
    {
        get { return timingArray; }
        set { timingArray = value; }
    }
    public int[] KeyArray
    {
        get { return keyArray; }
        set { keyArray = value; }
    }
    public AudioClip GetAudioClip(){
        AudioClip aClip;

        if(GameObject.Find("LocalResources") == null){
            aClip = Resources.Load<AudioClip>("Music/" + path + "/music");
        }else{
            Debug.Log("aclip:" + path + "/music");
            GameObject gameObject = GameObject.Find("LocalResources");
            LocalResources localResources = gameObject.GetComponent<LocalResources>();
            aClip = (AudioClip)localResources.GetLoadFile(path + "/music");
            Debug.Log(aClip);
        }
        return aClip;
    }
    public Sprite GetImage()
    {
        Texture2D texture = null;
        Sprite sprite = null;

        if (GameObject.Find("LocalResources") == null)
        {
            texture = Resources.Load<Texture>("Music/" + path + "/image") as Texture2D;
            if(texture != null)
            {
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
        }
        else
        {
            Debug.Log("aclip:" + path + "/image");
            GameObject gameObject = GameObject.Find("LocalResources");
            LocalResources localResources = gameObject.GetComponent<LocalResources>();

            Debug.Log("local" + localResources);
            texture = (UnityEngine.Texture)localResources.GetLoadFile(path + "/image") as Texture2D;
            Debug.Log("texture" + texture);
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        return sprite;
    }
    public string GetDescribe()
    {
        return "Artist:" + inf.artist + "  Arranger:" + inf.arranger + "  Author:" + inf.author;
    }
}
