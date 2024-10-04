using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventClick : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
	public int SceneNum;
	private GameObject Cam;
	[SerializeField] public Vector2 CamPos;

	public void Awake( )
	{
		Cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		CamPos = new Vector2( Cam.transform.position.x, Cam.transform.position.y );
		SceneController.instance.NextLevel(SceneNum, CamPos);
		Debug.Log( "Clicked" );

	}

	public void OnPointerUp(PointerEventData eventData)
	{
		
	}


}
