using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkillHttpRequest : MonoBehaviour {

	private HeroDetailController heroDetailController;
	private SkillScrollList skillController;

	public void GetSkillById(string skillId, HeroDetailController controller){
		heroDetailController = controller;
		StartCoroutine (GetSkillById(skillId));
	}

	public void GetAllSkills(SkillScrollList controller){
		skillController = controller;
		StartCoroutine (GetAllSkills());
	}

	IEnumerator GetSkillById(string skillId){
		Debug.Log ("skillId = " + skillId);
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
}
