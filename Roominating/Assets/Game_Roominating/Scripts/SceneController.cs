using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public static SceneController instance;
	[SerializeField] Animator transitionAnim;
	public Vector2 CurretCamPos;

	private void Awake( )
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad( gameObject );
		} else
		{
			Destroy(gameObject);
		}
	}
	public void NextLevel(int Scene, Vector3 CamPos)
	{
		StartCoroutine(LoadLevel(Scene));
		CurretCamPos = CamPos;

	}

	public void BackToMainMenu( ) {
		StartCoroutine( MainMenu() );
	}

	IEnumerator LoadLevel(int Scene)
	{
		transitionAnim.SetTrigger( "End" );
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadSceneAsync(Scene);
		transitionAnim.SetTrigger( "Start" );

	}

	IEnumerator MainMenu( ) {
		transitionAnim.SetTrigger( "End" );
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadSceneAsync( "Test_Scene" );
		//GameObject.FindGameObjectWithTag( "MainCamera" ).GetComponent<CameraController>().MoveCam( CurretCamPos );
		transitionAnim.SetTrigger( "Start" );
	}
}
