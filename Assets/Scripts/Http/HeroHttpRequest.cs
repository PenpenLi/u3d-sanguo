using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public interface IHeroHttpRequestDelegate
{
	void GetAllHeroSuccess(List<HeroModel> heros);
}

public interface IHeroSelectHttpRequestDelegate
{
	void SelectHeroSuccess();
	void DeSelectHeroSuccess();
	void GetSelectedHeroSuccess(List<HeroModel> heros);
}

public class HeroHttpRequest : MonoBehaviour
{
	private IHeroHttpRequestDelegate heroController;
	private IHeroSelectHttpRequestDelegate heroSelectController;
	
	public void getAllHero(IHeroHttpRequestDelegate controller){
		heroController = controller;
		StartCoroutine (HttpGetAllHero());
	}

	public void selectHero(HeroModel model, int index, IHeroSelectHttpRequestDelegate controller){
		heroSelectController = controller;
		StartCoroutine (HttpSelectHero(model, index));
	}

	public void deselectHero(HeroModel model, IHeroSelectHttpRequestDelegate controller){
		heroSelectController = controller;
		StartCoroutine (HttpDeSelectHero(model));
	}

	public void deselectHero(int positon, IHeroSelectHttpRequestDelegate controller){
		heroSelectController = controller;
		StartCoroutine (HttpDeSelectHero(positon));
	}

	public void getSelectedHeros(IHeroSelectHttpRequestDelegate controller){
		heroSelectController = controller;
		StartCoroutine (HttpGetSelectedHeros());
	}

	IEnumerator HttpGetAllHero(){

		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/hero/all/user_hero");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			
		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<List<HeroModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<HeroModel>>> (text);
				if (responseModel.code == 200) {
					List<HeroModel> heros = responseModel.data;
					heroController.GetAllHeroSuccess (heros);
				} else {
					
				}
			}
		}
	}

	IEnumerator HttpSelectHero(HeroModel model, int index){
		WWWForm pars = new WWWForm ();
		pars.AddField ("userHeroId", model.userHeroId);
		pars.AddField ("position", index);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/hero/select_hero", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<object> responseModel = JsonUtility.FromJson<ResponseModel<object>> (text);
				if (responseModel.code == 200) {
					heroSelectController.SelectHeroSuccess ();
				} else {

				}
			}
		}
	}

	IEnumerator HttpDeSelectHero(HeroModel model){
		WWWForm pars = new WWWForm ();
		pars.AddField ("userHeroId", model.userHeroId);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/hero/deselect_hero", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<object> responseModel = JsonUtility.FromJson<ResponseModel<object>> (text);
				if (responseModel.code == 200) {
					heroSelectController.DeSelectHeroSuccess ();
				} else {

				}
			}
		}
	}

	IEnumerator HttpDeSelectHero(int position){
		WWWForm pars = new WWWForm ();
		pars.AddField ("position", position);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/hero/deselect_hero", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<object> responseModel = JsonUtility.FromJson<ResponseModel<object>> (text);
				if (responseModel.code == 200) {
					heroSelectController.DeSelectHeroSuccess ();
				} else {

				}
			}
		}
	}

	IEnumerator HttpGetSelectedHeros(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/hero/selected");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<List<HeroModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<HeroModel>>> (text);
				if (responseModel.code == 200) {
					List<HeroModel> heros = responseModel.data;
					heroSelectController.GetSelectedHeroSuccess (heros);
				} else {

				}
			}
		}
	}
}

