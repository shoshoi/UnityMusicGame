using UnityEngine;

public class ControllManager : MonoBehaviour {
    private readonly string[] keybord = new string[] { "z", "x", "c", "v", "b" };
    public GameObject clapObject;
    private AudioSource clap;
    private NotesManager notesManager;

    private NotesLineEffect[] notesLineEffects;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;
    public GameObject line5;

    void Start () {
        clapObject = GameObject.Find("Clap");
        clap = clapObject.GetComponent<AudioSource>();

        notesManager = NotesManager.Instance;
        notesLineEffects = new NotesLineEffect[5];
        notesLineEffects[0] = line1.GetComponent<NotesLineEffect>();
        notesLineEffects[1] = line2.GetComponent<NotesLineEffect>();
        notesLineEffects[2] = line3.GetComponent<NotesLineEffect>();
        notesLineEffects[3] = line4.GetComponent<NotesLineEffect>();
        notesLineEffects[4] = line5.GetComponent<NotesLineEffect>();
    }
	
	void Update ()
    {
        bool isKeyDown = false;

        // キー押下時、ノートをシークする
        for(int i = 0; i < keybord.Length; i++)
        {
            if (Input.GetKeyDown(keybord[i]))
            {
                isKeyDown = true;                
                notesManager.NoteSeek(i);
            }
        }
        // キー押下時、効果音を再生する
        if (isKeyDown)
        {
            if(clap.time > 0)
            {
                clap.Stop();
            }
            clap.Play();
        }
        // 押下したキーに対応するノーツエフェクトを再生する
        for (int i = 0; i < keybord.Length; i++)
        {
            if (Input.GetKey(keybord[i]))
            {
                notesLineEffects[i].Play();
            }
        }

    }
}
