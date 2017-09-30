using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillUpController : MonoBehaviour {

	public Button backBtn;
	public Image pref;
	public ScrollRect skillScrollList;

	public Text skillPointText;

	private UserHttpRequest userRequest;
	private SkillHttpRequest skillRequest;

	private List<SkillModel> skillList;
	private List<Image> items;

	private UserModel currentUserModel;

	void Awake(){
		backBtn.onClick.AddListener (BackClick);

		userRequest = Singleton<UserHttpRequest>.Instance;
		userRequest.GetSkillPointSuccess += GetSkillPointSuccess;

		skillRequest = Singleton<SkillHttpRequest>.Instance;
		skillRequest.GetAllUserUpSkillsSuccess += GetAllUserUpSkillsSuccess;
		skillRequest.SkillUpSuccess += SkillUpSuccess;

		SkillUpSkillItem.SkillLevelUp += SkillLevelUp;
	}

	void OnDestroy(){
		userRequest.GetSkillPointSuccess -= GetSkillPointSuccess;
		skillRequest.GetAllUserUpSkillsSuccess -= GetAllUserUpSkillsSuccess;
		skillRequest.SkillUpSuccess -= SkillUpSuccess;

		SkillUpSkillItem.SkillLevelUp -= SkillLevelUp;
	}

	// Use this for initialization
	void Start () {
		items = new List<Image> ();
		skillList = new List<SkillModel> ();

		userRequest.GetSkillPoint ();
		skillRequest.GetAllUserUpSkills ();
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		foreach(Image bt in items){
			Destroy (bt.gameObject);
		}
		items.Clear ();
		if(skillList != null){
			foreach(SkillModel hero in skillList){
				Image bt = Instantiate (pref);
				items.Add (bt);
				bt.transform.SetParent (skillScrollList.content.transform, true);

				SkillUpSkillItem item = bt.GetComponent<SkillUpSkillItem> ();
				item.Bind (hero);
			}
		}
	}

	void RefreshTopUI(){
		skillPointText.text = "战法经验:" + currentUserModel.skillPoint;
	}

	void BackClick(){
		SceneManager.LoadScene ("center");
	}

	public void GetSkillPointSuccess(UserModel userModel){
		currentUserModel = userModel;
		RefreshTopUI ();
	}

	public void GetAllUserUpSkillsSuccess(List<SkillModel> skills){
		skillList = skills;
		RefreshDisplay ();
	}

	public void SkillUpSuccess(SkillModel skill){
		userRequest.GetSkillPoint ();
		skillRequest.GetAllUserUpSkills ();
	}

	public void SkillLevelUp(SkillModel skill){
		skillRequest.SkillUp (skill);
	}
}
