using UnityEngine;

public class CameraController : MonoBehaviour
{
	Vector3 inputDir = new Vector3(0, 0, 0);
	public float MaxX = 20f;
	public float MaxY = 20f;

	public bool CanMoveCam;

	public int edgeScrollSize = 20;

	private void Start( )
	{
		CanMoveCam = true;
	}
	private void Update( )
	{
		if(CanMoveCam)
		{

			if(Input.mousePosition.x < edgeScrollSize && transform.position.x >= -MaxX)
			{
				inputDir.x = -.25f;
			} else
			{
				inputDir.x = 0f;
			}
			if(Input.mousePosition.y < edgeScrollSize && transform.position.y >= -MaxY)
			{
				inputDir.y = -.25f;
			} else
			{
				inputDir.y = 0f;

			}
			if(Input.mousePosition.x > Screen.width - edgeScrollSize && transform.position.x <= MaxX)
			{
				inputDir.x = +.25f;
			}

			if(Input.mousePosition.y > Screen.height - edgeScrollSize && transform.position.y <= MaxY)
			{
				inputDir.y = +.25f;
			}
		}


		float moveSpeed = 10f;
		transform.position += inputDir * moveSpeed * Time.deltaTime;


	}
}
