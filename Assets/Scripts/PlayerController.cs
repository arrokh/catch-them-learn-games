using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private LeanTweenType typeEase = LeanTweenType.easeOutElastic;

    private bool isMoving = false;

    private bool swipedSideways;

    private float deltaX,
                  deltaY,
                  distance;

    private Vector3 rotatePlayer;

    public bool canMove = true;

	void Start () 
    {
        rotatePlayer = Vector3.zero;
        rotatePlayer.y = 90;
	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
            Move("forward");
        if (Input.GetKeyUp(KeyCode.D))
            Move("right");
        if (Input.GetKeyUp(KeyCode.A))
            Move("left");
    }

    public void Move(string state)
    {
        if (!isMoving)
        {
            switch (state)
            {
                case "forward":
                    isMoving = true;
                    if (rotatePlayer.y == 0 || rotatePlayer.y == 360)
                        LeanTween.moveZ(this.gameObject, (this.transform.position.z + 2.0f), moveSpeed).setEase(typeEase).setOnComplete(FinishMoving);
                    else if (rotatePlayer.y == 90)                                    
                        LeanTween.moveX(this.gameObject, (this.transform.position.x + 2.0f), moveSpeed).setEase(typeEase).setOnComplete(FinishMoving);
                    else if (rotatePlayer.y == 180)                                   
                        LeanTween.moveZ(this.gameObject, (this.transform.position.z - 2.0f), moveSpeed).setEase(typeEase).setOnComplete(FinishMoving);
                    else if (rotatePlayer.y == 270)                                   
                        LeanTween.moveX(this.gameObject, (this.transform.position.x - 2.0f), moveSpeed).setEase(typeEase).setOnComplete(FinishMoving);
                    break;
                case "right":
                    isMoving = true;
                    if (rotatePlayer.y >= 360)
                        rotatePlayer.y = 0;
                    rotatePlayer.y += 90.0f;
                    LeanTween.rotate(this.gameObject, rotatePlayer, moveSpeed).setEase(typeEase).setOnComplete(FinishMoving);
                    break;
                case "left":
                    isMoving = true;
                    if (rotatePlayer.y <= 0)
                        rotatePlayer.y = 360;
                    rotatePlayer.y -= 90.0f;
                    LeanTween.rotate(this.gameObject, rotatePlayer, moveSpeed).setEase(typeEase).setOnComplete(FinishMoving);
                    break;
                default:
                    break;
            }    
        }
    }

    private void FinishMoving()
    {
        isMoving = false;
    }
}
