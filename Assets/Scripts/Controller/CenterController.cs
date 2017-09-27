using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CenterController : MonoBehaviour {

	public Button backBtn;

	public Button selectHeroBtn;

	public Button selectSkillBtn;
	public Button heroIntoBtn;

	public Button fenJieHeroBtn;
	public Button skillIntoBtn;
	public Button skillUpBtn;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener (BackClick);
		selectHeroBtn.onClick.AddListener (SelectHeroClick);

		selectSkillBtn.onClick.AddListener (SelectSkillClick);
	}

	// Update is called once per frame
	void Update () {

	}

	void BackClick(){
		SceneManager.LoadScene ("Main");
	}

	void SelectHeroClick(){
		SceneManager.LoadScene ("HeroSelect");
	}

	void SelectSkillClick(){
		SceneManager.LoadScene ("SkillSelect");
	}
}
