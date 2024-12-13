using UnityEngine;

public class GameMenuScript : MonoBehaviour
{
    public float minX, maxX, smoothSpeed;

    static public bool isFollowing;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();

        isFollowing = true;
    }

    private void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane));

        if (isFollowing)
        {
            float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
            float targetX = Mathf.Lerp(transform.position.x, clampedX, Time.deltaTime * smoothSpeed);
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }
}
