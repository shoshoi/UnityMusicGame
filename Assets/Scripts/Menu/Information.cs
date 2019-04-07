using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour {
    public GameObject title;
    public GameObject describe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
        GameParameter gameParameter = GameParameter.Instance();

        Text text = title.GetComponent<Text>();
        text.text = gameParameter.GetSelectMusicData().Inf.title;
        text = describe.GetComponent<Text>();
        text.text = gameParameter.GetSelectMusicData().GetDescribe();

	}
}
