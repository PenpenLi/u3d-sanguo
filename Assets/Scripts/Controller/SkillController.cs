using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillController : MonoBehaviour {

	public Button backBtn;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener (BackClick);
	}

	// Update is called once per frame
	void Update () {

	}

	void BackClick(){
		SceneManager.LoadScene ("Main");
	}
}
