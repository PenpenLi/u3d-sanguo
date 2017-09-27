using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSkillScrollList : MonoBehaviour {
	private List<SkillModel> skillList;
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
		if(skillList != null){
			foreach(SkillModel skill in skillList){
				Button bt = Instantiate (btn);
				btns.Add (bt);
				bt.transform.SetParent (transform, true);

				SkillSkillItem item = bt.GetComponent<SkillHeroItem> ();
				item.Bind (skill, this);
			}
		}
	}

	public void RefreshSkills(List<SkillModel> skills, SkillSelectController controller){
		this.skillList = skills;
		this.skillSelectController = controller;
		RefreshDisplay ();
	}

	public void ItemClick(SkillModel skill){
		this.skillSelectController.SkillItemClick (skill);
	}
}
