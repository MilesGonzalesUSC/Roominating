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

	public void Awake( )
	{
		Cam = FindObjectOfType<Camera>().gameObject;
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		SceneController.instance.NextLevel(SceneNum);
		Debug.Log( "Clicked" );

	}

	public void OnPointerUp(PointerEventData eventData)
	{
		
	}


}
