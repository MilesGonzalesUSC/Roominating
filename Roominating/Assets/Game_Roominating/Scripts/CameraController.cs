using UnityEngine;

public class CameraController : MonoBehaviour
{
	Vector3 inputDir = new Vector3(0, 0, 0);

	public int edgeScrollSize = 20;
	private void Update( )
	{

		if(Input.mousePosition.x < edgeScrollSize){
			inputDir.x = -.25f;
		}
		if(Input.mousePosition.y < edgeScrollSize){
			inputDir.y = -.25f;
		}
		if(Input.mousePosition.x > Screen.width - edgeScrollSize) { 
			inputDir.x = +.25f; 
		}
		if(Input.mousePosition.y > Screen.height - edgeScrollSize){
			inputDir.y = +.25f;
		}





		float moveSpeed = 10f;
		transform.position += inputDir * moveSpeed * Time.deltaTime;


	}
}
