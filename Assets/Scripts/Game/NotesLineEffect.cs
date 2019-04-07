using UnityEngine;

public class NotesLineEffect : MonoBehaviour {
    Renderer rend;
    Color defaultColor;
    Color alpha = new Color(0, 0, 0, 0.02f);

    void Start ()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
        rend.material.color -= new Color(0, 0, 0, 1f);
    }
	
	void Update () {
        if (rend.material.color.a >= 0)
            rend.material.color -= alpha;
    }
    public void Play()
    {
        rend.material.color = defaultColor;
    }
}
