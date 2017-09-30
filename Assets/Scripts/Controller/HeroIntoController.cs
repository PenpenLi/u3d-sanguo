using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroIntoController : MonoBehaviour {

	public Button backBtn;
	public ScrollRect content;

	private HeroHttpRequest heroRequest;

	private HeroIntoScrollList heroIntoScrollList; 

	void Awake(){
		backBtn.onClick.AddListener (BackClick);

		heroIntoScrollList = content.viewport.GetComponentInChildren<HeroIntoScrollList> ();

		heroRequest = Singleton<HeroHttpRequest>.Instance;
		heroRequest.GetAllHeroPiecesSuccess += GetAllHeroPiecesSuccess;
		heroRequest.IntoHeroSuccess += IntoHeroSuccess;
		HeroIntoItem.HeroIntoClick += HeroIntoClick;
	}

	void OnDestroy(){
		heroRequest.GetAllHeroPiecesSuccess -= GetAllHeroPiecesSuccess;
		heroRequest.IntoHeroSuccess -= IntoHeroSuccess;
		HeroIntoItem.HeroIntoClick -= HeroIntoClick;
	}

	// Use this for initialization
	void Start () {
		heroRequest.GetAllHeroPieces ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackClick(){
		SceneManager.LoadScene ("center");
	}

	public void GetAllHeroPiecesSuccess(List<ProductModel> products){
		heroIntoScrollList.RefreshProducts (products);
	}

	public void IntoHeroSuccess(HeroModel hero){
		heroRequest.GetAllHeroPieces ();
	}

	public void HeroIntoClick(ProductModel product){
		heroRequest.IntoHero (product);
	}
}
