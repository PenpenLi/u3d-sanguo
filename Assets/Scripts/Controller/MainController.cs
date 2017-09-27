using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

	private Button heroBtn;
	public Button skillBtn;
	public Button battleBtn;
	public Button rankBtn;
	public Button settingBtn;
	public Button centerBtn;
	public Button bagBtn;

	// Use this for initialization
	void Start () {
		GameObject heroBtnObject = GameObject.FindGameObjectWithTag ("HeroBtn");
		if(heroBtnObject != null){
			heroBtn = heroBtnObject.GetComponent<Button> ();
			if(heroBtn != null){
				heroBtn.onClick.AddListener (HeroClick);
			}
		}

		skillBtn.onClick.AddListener (SkillClick);
		battleBtn.onClick.AddListener (BattleClick);
		centerBtn.onClick.AddListener (CenterClick);
		bagBtn.onClick.AddListener (BagClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HeroClick(){
		SceneManager.LoadScene ("Hero");
	}

	void SkillClick(){
		SceneManager.LoadScene ("Skill");
	}

	void BattleClick(){
		SceneManager.LoadScene ("Chapter");
	}

	void CenterClick(){
		SceneManager.LoadScene ("Center");
	}

	void BagClick(){
		SceneManager.LoadScene ("Bag");
	}
}
