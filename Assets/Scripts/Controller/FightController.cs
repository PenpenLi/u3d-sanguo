using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour, IFightHttpRequestDelegate {
	
	public static BattleModel battleModel;

	public Button backBtn;

	public Text resultText;
	public Text durationText;
	public Text leftHeroText;
	public Text rightHeroText;

	public ScrollRect scrollView;
	private FightScrollList fightScrollList;

	private FightHttpRequest fightRequest;

	private List<FightItemModel> totalFightItems;
	private int index = 0;
	private bool isOver = false;
	private float startTime = 0.0f;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener (BackClick);

		leftHeroText.text = "XXXX";
		rightHeroText.text = battleModel.battleTitle;
		resultText.gameObject.SetActive (false);

		fightRequest = Singleton<FightHttpRequest>.Instance;
		fightRequest.FightBattle (battleModel.battleId, this);

		fightScrollList = scrollView.viewport.GetComponentInChildren<FightScrollList>();

		InvokeRepeating ("executePerSecond", 1.0f, 1.0f);
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if(!isOver){
			durationText.text = ConvertHelper.RoundToStr(Time.time - startTime, 1);
		}
	}

	void BackClick(){
		SceneManager.LoadScene ("Battle");
	}

	public void FightSuccess (List<FightItemModel> fightItems){
		totalFightItems = fightItems;
	}

	void executePerSecond(){
		if (totalFightItems.Count > 0 && index < totalFightItems.Count) {
			FightItemModel itemModel = totalFightItems [index];
			fightScrollList.AddFightItem (itemModel);
			if (itemModel.prop.Equals ("win")) {
				resultText.text = "战斗胜利！";
			}
			if (itemModel.prop.Equals ("lost")) {
				resultText.text = "战斗失败！";
			}
			if (itemModel.prop.Equals ("tie")) {
				resultText.text = "战斗平局！";
			}
			index++;
		} else {
			if(index >= totalFightItems.Count){
				isOver = true;
				CancelInvoke ();

				durationText.gameObject.SetActive (false);
				resultText.gameObject.SetActive (true);
			}
		}
	}
}
