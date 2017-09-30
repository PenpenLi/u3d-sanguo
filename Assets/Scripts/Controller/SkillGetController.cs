using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillGetController : MonoBehaviour {

	public Button backBtn;
	public ScrollRect heroScrollList;

	private List<HeroModel> heroList;
	private List<Image> items;

	public Image pref;

	private HeroHttpRequest heroRequest;

	void Awake(){
		backBtn.onClick.AddListener (BackClick);

		heroRequest = Singleton<HeroHttpRequest>.Instance;
		heroRequest.GetAllHeroSuccess += GetAllHeroSuccess;
		heroRequest.ConvertToSkillSuccess += ConvertToSkillSuccess;
		SkillGetItem.HeroToSkillClick += HeroToSkillClick;
	}

	void OnDestroy(){
		heroRequest.GetAllHeroSuccess -= GetAllHeroSuccess;
		heroRequest.ConvertToSkillSuccess -= ConvertToSkillSuccess;
		SkillGetItem.HeroToSkillClick -= HeroToSkillClick;
	}

	// Use this for initialization
	void Start () {
		items = new List<Image> ();

		heroRequest.getAllHero ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RefreshDisplay(){
		foreach(Image bt in items){
			Destroy (bt.gameObject);
		}
		items.Clear ();
		if(heroList != null){
			foreach(HeroModel hero in heroList){
				Image bt = Instantiate (pref);
				items.Add (bt);
				bt.transform.SetParent (heroScrollList.content.transform, true);

				SkillGetItem item = bt.GetComponent<SkillGetItem> ();
				item.Bind (hero);
			}
		}
	}

	void BackClick(){
		SceneManager.LoadScene ("center");
	}

	public void GetAllHeroSuccess(List<HeroModel> heros){
		heroList = heros;
		RefreshDisplay ();
	}

	public void HeroToSkillClick(HeroModel hero){
		heroRequest.ConvertToSkill(hero);
	}

	public void ConvertToSkillSuccess(SkillModel skill){
		heroRequest.getAllHero ();
	}
}
