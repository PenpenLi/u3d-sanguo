using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ChapterHttpRequest : MonoBehaviour
{
	private ChapterScrollList chapterController;
	private BattleScrollList battleController;
	
	public void getAllChapter(ChapterScrollList controller){
		chapterController = controller;
		StartCoroutine (HttpGetAllChapter());
	}

	public void getAllBattleByChapterId(int chapterId, BattleScrollList controller){
		battleController = controller;
		StartCoroutine (HttpGetAllBattleByChapterId(chapterId));
	}

	IEnumerator HttpGetAllChapter(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/battle/chapter/all/user_chapter");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			
		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<List<ChapterModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<ChapterModel>>> (text);
				if (responseModel.code == 200) {
					chapterController.GetAllChapterSuccess (responseModel.data);
				} else {
					
				}
			}
		}
	}

	IEnumerator HttpGetAllBattleByChapterId(int chapterId){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/battle/all/user_battle?chapterId="+chapterId);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<List<BattleModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<BattleModel>>> (text);
				if (responseModel.code == 200) {
					battleController.GetAllBattleByChapterIdSuccess (responseModel.data);
				} else {

				}
			}
		}
	}

}

