using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHeroScrollList : MonoBehaviour {

	private List<HeroModel> heroList;
	private List<Button> btns;

	public Button btn;

	private SkillSelectController skillSelectController;

	// Use this for initialization
	void Start () {
		btns = new List<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RefreshDisplay(){
		foreach(Button bt in btns){
			Destroy (bt.gameObject);
		}
		btns.Clear ();
		if(heroList != null){
			foreach(HeroModel hero in heroList){
				Button bt = Instantiate (btn);
				btns.Add (bt);
				bt.transform.SetParent (transform, true);

				SkillHeroItem item = bt.GetComponent<SkillHeroItem> ();
				item.Bind (hero, this);
			}
		}
	}

	public void RefreshHeros(List<HeroModel> heros, SkillSelectController controller){
		this.heroList = heros;
		this.skillSelectController = controller;
		RefreshDisplay ();
	}

	public void ItemClick(HeroModel hero){
		this.skillSelectController.HeroItemClick (hero);
	}
}