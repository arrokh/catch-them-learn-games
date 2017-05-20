using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float panningSpeed = 0.025f;

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private Transform[] cameraTargetPosition = new Transform[4];

    private Vector3 lastPosition,
                    deltaPosition;

    private int rotationPoint;

    private float viewSize;

	void Start () 
    {
        rotationPoint = 3;

        viewSize = 5.0f;
	}
	
	void Update ()
    {
        viewSize -= Input.mouseScrollDelta.y;

        if (Input.GetMouseButtonDown(1))
            lastPosition = Input.mousePosition;

        if (Input.GetMouseButton(1))
        {
            deltaPosition = -(Input.mousePosition - lastPosition);

            Camera.main.transform.Translate(
                    deltaPosition.x * panningSpeed,
                    deltaPosition.y * panningSpeed,
                    0.0f
                );

            lastPosition = Input.mousePosition;
        }
	}

    void LateUpdate()
    {
        Camera.main.transform.rotation = Quaternion.Lerp(
                Camera.main.transform.rotation,
                cameraTargetPosition[rotationPoint].rotation,
                Time.deltaTime * moveSpeed
            );

        Camera.main.transform.position = Vector3.Lerp(
                Camera.main.transform.position, 
                player.transform.position, 
                Time.deltaTime * 1.0f
            );

        Camera.main.orthographicSize = Mathf.Clamp(
                viewSize,
                2.0f,
                7.0f
            );
    }

    public void RotateTo(string direction)
    {
        switch (direction)
        {
            case "left":
                if (rotationPoint > 2)
                    rotationPoint = 0;
                else
                    rotationPoint++;
                break;
            case "right":
                if (rotationPoint < 1)
                    rotationPoint = 3;
                else
                    rotationPoint--;
                break;
            default:
                break;
        }
    }
}
