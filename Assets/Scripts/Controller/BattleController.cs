using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

	public static ChapterModel chapterModel;

	public Button backBtn;
	public Text descText;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener (BackClick);

		descText.text = chapterModel.chapterDesc;
	}

	// Update is called once per frame
	void Update () {

	}

	void BackClick(){
		SceneManager.LoadScene ("Chapter");
	}
}
