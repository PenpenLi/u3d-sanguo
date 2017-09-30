using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CenterController : MonoBehaviour {

	public Button backBtn;

	public Button selectHeroBtn;

	public Button heroIntoBtn;
	public Button selectSkillBtn;

	public Button skillGetBtn;
	public Button skillIntoBtn;
	public Button skillUpBtn;
	public Button skillExpGetBtn;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener (BackClick);
		selectHeroBtn.onClick.AddListener (SelectHeroClick);

		selectSkillBtn.onClick.AddListener (SelectSkillClick);
		heroIntoBtn.onClick.AddListener (HeroIntoClick);

		skillGetBtn.onClick.AddListener (SkillGetClick);
		skillIntoBtn.onClick.AddListener (SkillIntoClick);
		skillUpBtn.onClick.AddListener (SkillUpClick);
		skillExpGetBtn.onClick.AddListener (SKillExpClick);
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

	void HeroIntoClick(){
		SceneManager.LoadScene ("HeroInto");
	}

	void SkillGetClick(){
		SceneManager.LoadScene ("SkillGet");
	}

	void SkillIntoClick(){
		SceneManager.LoadScene ("SkillInto");
	}

	void SkillUpClick(){
		SceneManager.LoadScene ("SkillUp");
	}

	void SKillExpClick(){
		SceneManager.LoadScene ("SkillExp");
	}
}
