using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
	
public class LoginController : MonoBehaviour {

	private Button loginBtn;
	private Button registeBtn;

	private InputField accountInput;
	private InputField passwordInput;

	private UserHttpRequest loginRequest;

	// Use this for initialization
	void Start () {
		GameObject loginBtnObject = GameObject.FindGameObjectWithTag ("LoginBtn");
		if(loginBtnObject != null){
			loginBtn = loginBtnObject.GetComponent<Button> ();
			if(loginBtn != null){
				loginBtn.onClick.AddListener (LoginClick);
			}
		}
		GameObject registeBtnObject = GameObject.FindGameObjectWithTag ("RegisteBtn");
		if(registeBtnObject != null){
			registeBtn = registeBtnObject.GetComponent<Button> ();
			if(registeBtn != null){
				registeBtn.onClick.AddListener (RegisteClick);
			}
		}
		GameObject accountInputObject = GameObject.FindGameObjectWithTag ("AccountInput");
		if(accountInputObject != null){
			accountInput = accountInputObject.GetComponent<InputField> ();
			if(accountInput != null){
				//accountInput.on onClick.AddListener (RegisteClick);
			}
		}
		GameObject passwordInputObject = GameObject.FindGameObjectWithTag ("PasswordInput");
		if(passwordInputObject != null){
			passwordInput = passwordInputObject.GetComponent<InputField> ();
			if(passwordInput != null){
				//registeBtn.onClick.AddListener (RegisteClick);
			}
		}

		GameObject httpRequestObject = GameObject.FindGameObjectWithTag ("LoginHttpRequest");
		if(httpRequestObject != null){
			loginRequest = httpRequestObject.GetComponent<UserHttpRequest> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoginClick(){
		Debug.Log ("login click account = " + accountInput.text + ", password = " + passwordInput.text);

		loginRequest.Login (accountInput.text, passwordInput.text, this);
	}

	void RegisteClick(){
		Debug.Log ("registe click account = " + accountInput.text + ", password = " + passwordInput.text);

		loginRequest.Registe (accountInput.text, passwordInput.text, this);
	}

	public void RegisteSuccess(){
		
	}

	public void LoginSuccess(){
		SceneManager.LoadScene ("Main");
	}
}
