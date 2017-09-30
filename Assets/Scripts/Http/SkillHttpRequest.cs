using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SkillHttpRequest : MonoBehaviour {

	private HeroDetailController heroDetailController;
	private SkillScrollList skillController;

	public Action<List<SkillModel>> GetAllUserSkillsSuccess;
	public Action<List<SkillModel>> GetAllIntoSkillsSuccess;
	public Action<SkillModel> SkillUpSuccess;
	public Action<List<SkillModel>> GetAllUserUpSkillsSuccess;

	public void GetSkillById(string skillId, HeroDetailController controller){
		heroDetailController = controller;
		StartCoroutine (GetSkillById(skillId));
	}

	public void GetAllSkills(SkillScrollList controller){
		skillController = controller;
		StartCoroutine (GetAllSkills());
	}

	public void GetAllUserSkills(){
		StartCoroutine (HttpGetAllUserSkills());
	}

	public void GetAllIntoSkills(){
		StartCoroutine (HttpGetAllIntoSkills());
	}

	public void SkillUp(SkillModel skill){
		StartCoroutine (HttpSkillUp(skill));
	}

	public void GetAllUserUpSkills(){
		StartCoroutine (HttpGetAllUserUpSkills());
	}

	IEnumerator HttpGetAllUserUpSkills(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/skill/user_up_skills");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			Debug.Log (request.error);
		} else {
			if (request.responseCode == 200) {
				string text = request.downloadHandler.text;
				Debug.Log ("response " + text);

				ResponseModel<List<SkillModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<SkillModel>>> (text);
				if(responseModel.code == 200){
					if(GetAllUserUpSkillsSuccess != null){
						GetAllUserUpSkillsSuccess (responseModel.data);
					}
				}
			} else {
				Debug.Log ("responseCode is not OK");
			}
		}
	}

	IEnumerator HttpSkillUp(SkillModel skill){
		WWWForm pars = new WWWForm ();
		pars.AddField ("userSkillId", skill.userSkillId);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/skill/level_up", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			Debug.Log (request.error);
		} else {
			if (request.responseCode == 200) {
				string text = request.downloadHandler.text;
				Debug.Log ("response " + text);

				ResponseModel<SkillModel> responseModel = JsonUtility.FromJson<ResponseModel<SkillModel>> (text);
				if(responseModel.code == 200){
					if(SkillUpSuccess != null){
						SkillUpSuccess (responseModel.data);
					}
				}
			} else {
				Debug.Log ("responseCode is not OK");
			}
		}
	}

	IEnumerator HttpGetAllIntoSkills(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/skill/user_into_skills");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			Debug.Log (request.error);
		} else {
			if (request.responseCode == 200) {
				string text = request.downloadHandler.text;
				Debug.Log ("response " + text);

				ResponseModel<List<SkillModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<SkillModel>>> (text);
				if(responseModel.code == 200){
					if(GetAllIntoSkillsSuccess != null){
						GetAllIntoSkillsSuccess (responseModel.data);
					}
				}
			} else {
				Debug.Log ("responseCode is not OK");
			}
		}
	}

	IEnumerator GetSkillById(string skillId){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/skill/" + skillId);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			Debug.Log (request.error);
		} else {
			if (request.responseCode == 200) {
				string text = request.downloadHandler.text;
				Debug.Log ("response " + text);

				ResponseModel<SkillModel> responseModel = JsonUtility.FromJson<ResponseModel<SkillModel>> (text);
				if(responseModel.code == 200){
					heroDetailController.GetSkillByIdSuccess (responseModel.data);
				}
			} else {
				Debug.Log ("responseCode is not OK");
			}
		}
	}

	IEnumerator GetAllSkills(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/skill/all");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			Debug.Log (request.error);
		} else {
			if (request.responseCode == 200) {
				string text = request.downloadHandler.text;
				Debug.Log ("response " + text);

				ResponseModel<List<SkillModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<SkillModel>>> (text);
				if(responseModel.code == 200){
					skillController.GetAllSkillSuccess (responseModel.data);
				}
			} else {
				Debug.Log ("responseCode is not OK");
			}
		}
	}

	IEnumerator HttpGetAllUserSkills(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/skill/user_skills");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			Debug.Log (request.error);
		} else {
			if (request.responseCode == 200) {
				string text = request.downloadHandler.text;
				Debug.Log ("response " + text);

				ResponseModel<List<SkillModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<SkillModel>>> (text);
				if(responseModel.code == 200){
					if(GetAllUserSkillsSuccess != null){
						GetAllUserSkillsSuccess (responseModel.data);
					}
				}
			} else {
				Debug.Log ("responseCode is not OK");
			}
		}
	}
}
