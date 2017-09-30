using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroSelectController : MonoBehaviour, IHeroHttpRequestDelegate, IHeroSelectHttpRequestDelegate {

	public Button backBtn;
	public Text txt;

	public Button oneHeroBtn;
	public Button twoHeroBtn;
	public Button threeHeroBtn;

	public Button oneHeroRemoveBtn;
	public Button twoHeroRemoveBtn;
	public Button threeHeroRemoveBtn;

	public ScrollRect scrollView;
	private HeroSelectScrollList selectScrollList;

	private HeroHttpRequest heroRequest;
	private int selectedPosition;

	void Awake(){
		heroRequest = Singleton<HeroHttpRequest>.Instance;
		heroRequest.GetAllHeroSuccess += GetAllHeroSuccess;
	}

	void OnDestroy(){
		heroRequest.GetAllHeroSuccess -= GetAllHeroSuccess;
	}


	void Start(){
		backBtn.onClick.AddListener (BackClick);

		oneHeroBtn.onClick.AddListener (OneHeroClick);
		twoHeroBtn.onClick.AddListener (TwoHeroClick);
		threeHeroBtn.onClick.AddListener (ThreeHeroClick);

		oneHeroRemoveBtn.onClick.AddListener (OneHeroRemoveClick);
		twoHeroRemoveBtn.onClick.AddListener (TwoHeroRemoveClick);
		threeHeroRemoveBtn.onClick.AddListener (ThreeHeroRemoveClick);

		oneHeroRemoveBtn.gameObject.SetActive (false);
		twoHeroRemoveBtn.gameObject.SetActive (false);
		threeHeroRemoveBtn.gameObject.SetActive (false);

		heroRequest.getSelectedHeros (this);

		selectScrollList = scrollView.viewport.GetComponentInChildren<HeroSelectScrollList>();
		selectScrollList.heroSelectController = this;
	}

	void BackClick(){
		SceneManager.LoadScene ("Center");
	}

	void OneHeroClick(){
		OneSelected ();

		if (oneHeroBtn.GetComponentInChildren<Text> ().text.Equals("未选择")) {
			heroRequest.getAllHero ();
		} else {
			oneHeroRemoveBtn.gameObject.SetActive (true);
		}
	}

	void OneHeroRemoveClick(){
		DeSelectHero ();
	}

	void TwoHeroClick(){
		TwoSelected ();

		if (twoHeroBtn.GetComponentInChildren<Text> ().text.Equals("未选择")) {
			heroRequest.getAllHero ();
		}else{
			twoHeroRemoveBtn.gameObject.SetActive (true);
		}
	}

	void TwoHeroRemoveClick(){
		DeSelectHero ();
	}

	void ThreeHeroClick(){
		ThreeSelected ();

		if (threeHeroBtn.GetComponentInChildren<Text> ().text.Equals("未选择")) {
			heroRequest.getAllHero ();
		}else{
			threeHeroRemoveBtn.gameObject.SetActive (true);
		}
	}

	void ThreeHeroRemoveClick(){
		DeSelectHero ();
	}

	void OneSelected(){
		twoHeroRemoveBtn.gameObject.SetActive (false);
		threeHeroRemoveBtn.gameObject.SetActive (false);

		oneHeroBtn.GetComponentInChildren<Image> ().color = Color.white;
		twoHeroBtn.GetComponentInChildren<Image> ().color = Color.gray;
		threeHeroBtn.GetComponentInChildren<Image> ().color = Color.gray;

		selectedPosition = 1;
	}

	void TwoSelected(){
		oneHeroRemoveBtn.gameObject.SetActive (false);
		threeHeroRemoveBtn.gameObject.SetActive (false);

		oneHeroBtn.GetComponentInChildren<Image> ().color = Color.gray;
		twoHeroBtn.GetComponentInChildren<Image> ().color = Color.white;
		threeHeroBtn.GetComponentInChildren<Image> ().color = Color.gray;

		selectedPosition = 2;
	}

	void ThreeSelected(){
		oneHeroRemoveBtn.gameObject.SetActive (false);
		twoHeroRemoveBtn.gameObject.SetActive (false);

		oneHeroBtn.GetComponentInChildren<Image> ().color = Color.gray;
		twoHeroBtn.GetComponentInChildren<Image> ().color = Color.gray;
		threeHeroBtn.GetComponentInChildren<Image> ().color = Color.white;

		selectedPosition = 3;
	}

	public void RefreshSelectedHeros(List<HeroModel> heros){
		oneHeroBtn.GetComponentInChildren<Text> ().text = "未选择";
		twoHeroBtn.GetComponentInChildren<Text> ().text = "未选择";
		threeHeroBtn.GetComponentInChildren<Text> ().text = "未选择";

		foreach(HeroModel model in heros){
			switch(model.position){
			case 1:
				oneHeroBtn.GetComponentInChildren<Text> ().text = model.nickname;
				break;
			case 2:
				twoHeroBtn.GetComponentInChildren<Text> ().text = model.nickname;
				break;
			case 3:
				threeHeroBtn.GetComponentInChildren<Text> ().text = model.nickname;
				break;
			default:
				break;
			}
		}
	}

	// 选中一个武将
	public void SelectHero(HeroModel hero){
		heroRequest.selectHero (hero, selectedPosition, this);
	}
	// 
	public void DeSelectHero(){
		heroRequest.deselectHero (selectedPosition, this);
	}

	#region IHeroHttpRequestDelegate
	public void GetAllHeroSuccess(List<HeroModel> heros){
		selectScrollList.RefreshHeros (heros);
	}
	#endregion

	#region IHeroSelectHttpRequestDelegate
	public void SelectHeroSuccess(){
		// 更新待选武将列表
		heroRequest.getAllHero ();
		//更新已选武将列表
		heroRequest.getSelectedHeros(this);
	}
	public void DeSelectHeroSuccess(){
		// 更新待选武将列表
		heroRequest.getAllHero ();
		//更新已选武将列表
		heroRequest.getSelectedHeros(this);
	}
	public void GetSelectedHeroSuccess(List<HeroModel> heros){
		RefreshSelectedHeros (heros);
	}
	#endregion
}
