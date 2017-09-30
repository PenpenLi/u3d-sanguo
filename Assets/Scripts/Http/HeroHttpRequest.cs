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

	public Action<HeroModel> AddSkillSuccess;
	public Action<List<ProductModel>> GetAllHeroPiecesSuccess;
	public Action<HeroModel> IntoHeroSuccess;
	public Action<List<HeroModel>> GetAllHeroSuccess;
	public Action<SkillModel> ConvertToSkillSuccess;
	public Action<SkillModel> ConvertIntoSkillSuccess;
	public Action<List<HeroModel>> GetAllCanIntoHerosSuccess;
	public Action<List<HeroModel>> GetAllCanSkillPointHerosSuccess;
	public Action<UserModel> ConvertToSkillPointSuccess;

	public void getAllHero(){
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

	public void AddSkill(HeroModel hero, SkillModel skill, int position){
		StartCoroutine (HttpAddSkill(hero, skill, position));
	}

	public void GetAllHeroPieces(){
		StartCoroutine (HttpGetAllHeroPieces());
	}

	public void IntoHero(ProductModel product){
		StartCoroutine (HttpIntoHero(product));
	}

	public void ConvertToSkill(HeroModel hero){
		StartCoroutine (HttpConvertToSkill(hero));
	}

	public void ConvertIntoSkill(List<HeroModel> heros, SkillModel skill){
		StartCoroutine (HttpConvertIntoSkill(heros, skill));
	}

	public void ConvertToSkillPoint(HeroModel hero){
		StartCoroutine (HttpConvertToSkillPoint(hero));
	}

	public void GetAllCanIntoHeros(string userSkillId){
		StartCoroutine (HttpGetAllCanIntoHeros(userSkillId));
	}

	public void GetAllCanSkillPointHeros(){
		StartCoroutine (HttpGetAllCanSkillPointHeros());
	}

	IEnumerator HttpConvertToSkillPoint(HeroModel hero){
		WWWForm pars = new WWWForm ();
		pars.AddField ("userHeroId", hero.userHeroId);
		string urlPath = "http://127.0.0.1:8080/api/hero/convert_to_skill_point";
		UnityWebRequest request = UnityWebRequest.Post (urlPath, pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<UserModel> responseModel = JsonUtility.FromJson<ResponseModel<UserModel>> (text);
				if (responseModel.code == 200) {
					if(ConvertToSkillPointSuccess != null){
						ConvertToSkillPointSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
	}

	IEnumerator HttpGetAllCanSkillPointHeros(){
		string urlPath = "http://127.0.0.1:8080/api/hero/all/can_skill_point";
		UnityWebRequest request = UnityWebRequest.Get (urlPath);
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
					if(GetAllCanSkillPointHerosSuccess != null){
						GetAllCanSkillPointHerosSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
	}

	IEnumerator HttpGetAllCanIntoHeros(string userSkillId){
		string urlPath = "http://127.0.0.1:8080/api/hero/all/can_into_skill";
		urlPath += "?";
		urlPath += "userSkillId=" + userSkillId;
		UnityWebRequest request = UnityWebRequest.Get (urlPath);
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
					if(GetAllCanIntoHerosSuccess != null){
						GetAllCanIntoHerosSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
	}

	IEnumerator HttpConvertIntoSkill(List<HeroModel> heros, SkillModel skill){
		WWWForm pars = new WWWForm ();
		pars.AddField ("userSkillId", skill.userSkillId);
		List<string> userHeroIds = new List<string> ();
		foreach(HeroModel hero in heros){
			userHeroIds.Add (hero.userHeroId);
		}
		pars.AddField ("userHeroIds", Serialization<string>.ConvertToStr (new Serialization<string>(userHeroIds)));
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/hero/convert_into_skill", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<SkillModel> responseModel = JsonUtility.FromJson<ResponseModel<SkillModel>> (text);
				if (responseModel.code == 200) {
					if(ConvertIntoSkillSuccess != null){
						ConvertIntoSkillSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
	}

	IEnumerator HttpConvertToSkill(HeroModel hero){
		WWWForm pars = new WWWForm ();
		pars.AddField ("userHeroId", hero.userHeroId);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/hero/convert_to_skill", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<SkillModel> responseModel = JsonUtility.FromJson<ResponseModel<SkillModel>> (text);
				if (responseModel.code == 200) {
					if(ConvertToSkillSuccess != null){
						ConvertToSkillSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
	}

	IEnumerator HttpIntoHero(ProductModel product){
		WWWForm pars = new WWWForm ();
		pars.AddField ("productId", product.productId);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/hero/into_hero", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<HeroModel> responseModel = JsonUtility.FromJson<ResponseModel<HeroModel>> (text);
				if (responseModel.code == 200) {
					if(IntoHeroSuccess != null){
						IntoHeroSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
	}

	IEnumerator HttpGetAllHeroPieces(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/bag/product/all/hero_piece");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<List<ProductModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<ProductModel>>> (text);
				if (responseModel.code == 200) {
					if(GetAllHeroPiecesSuccess != null){
						GetAllHeroPiecesSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
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
					if(GetAllHeroSuccess != null){
						GetAllHeroSuccess (heros);
					}
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

	IEnumerator HttpAddSkill(HeroModel hero, SkillModel skill, int position){
		WWWForm pars = new WWWForm ();
		pars.AddField ("userHeroId", hero.userHeroId);
		pars.AddField ("userSkillId", skill.userSkillId);
		pars.AddField ("position", position);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/hero/add_skill", pars);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<HeroModel> responseModel = JsonUtility.FromJson<ResponseModel<HeroModel>> (text);
				if (responseModel.code == 200) {
					if(AddSkillSuccess != null){
						AddSkillSuccess (responseModel.data);
					}
				} else {

				}
			}
		}
	}
}

