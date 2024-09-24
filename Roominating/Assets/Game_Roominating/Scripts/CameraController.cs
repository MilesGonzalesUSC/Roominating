using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float moveSpeed = 5f; // Speed at which the camera moves
	public Vector3 centerPoint = new Vector3( 0, 0, 0 ); // The center point for the camera
	public float maxDistance = 5f; // Maximum distance from the center point
	public float followDistance = 2f; // How far the camera can follow the mouse

	private void Update( )
	{
		MoveCamera();
	}

	private void MoveCamera( )
	{
		// Get the mouse position in world space
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		mousePosition.z = transform.position.z; // Keep the camera's z position constant

		// Calculate the desired position based on mouse movement with a follow distance
		Vector3 desiredPosition = Vector3.Lerp( transform.position, mousePosition, moveSpeed * Time.deltaTime );

		// Calculate the distance from the center point
		float distanceFromCenter = Vector3.Distance( desiredPosition, centerPoint );

		// Clamp the position to within the maximum distance from the center
		if(distanceFromCenter > maxDistance)
		{
			Vector3 direction = (desiredPosition - centerPoint).normalized;
			desiredPosition = centerPoint + direction * maxDistance;
		}

		// Determine the target position by combining the center point and the mouse follow
		Vector3 targetPosition = centerPoint + (desiredPosition - centerPoint).normalized * followDistance;

		// Update the camera's position
		transform.position = Vector3.Lerp( transform.position, targetPosition, moveSpeed * Time.deltaTime );
	}
}
