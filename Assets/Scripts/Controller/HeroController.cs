using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour {

	private Button backBtn;

	void Awake(){
		
	}

	// Use this for initialization
	void Start () {
		GameObject backBtnObject = GameObject.FindGameObjectWithTag ("BackBtn");
		if(backBtnObject != null){
			backBtn = backBtnObject.GetComponent<Button> ();
			if(backBtn != null){
				backBtn.onClick.AddListener (BackClick);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackClick(){
		SceneManager.LoadScene ("Main");
	}
}
