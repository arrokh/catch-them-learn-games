using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour 
{
    public enum Move
    {
        VERTICAL,
        HORIZONTAL
    }

    public bool canMove = false;

    public Move move = Move.HORIZONTAL;

    [SerializeField]
    private int range = 2;

    [SerializeField]
    private LeanTweenType typeEase = LeanTweenType.easeInOutBack;

    private float rot = 0.0f;

	void Start () 
    {
        if (canMove)
            Move0();
        else
            Rotate();
	}

    public void ChangeMove(bool value)
    {
        if (value)
            move = Move.VERTICAL;
        else
            move = Move.HORIZONTAL;
    }

    private void Rotate()
    {
        if (rot >= 360)
            rot = 0.0f;
        rot += 90.0f;
        LeanTween.rotateY(this.gameObject, rot, 2.0f).setEase(typeEase).setOnComplete(Rotate).setDelay(1.0f);
    }

    private void Move0()
    {
        switch (move)
        {
            case Move.VERTICAL:
                LeanTween.moveZ(this.gameObject, this.transform.position.z + range, 1.0f).setEase(typeEase).setOnComplete(Move1).setDelay(1.0f);
                break;
            case Move.HORIZONTAL:
                LeanTween.moveX(this.gameObject, this.transform.position.x + range, 1.0f).setEase(typeEase).setOnComplete(Move1).setDelay(1.0f);
                break;
            default:
                break;
        }
    }

    private void Move1()
    {
        switch (move)
        {
            case Move.VERTICAL:
                LeanTween.moveZ(this.gameObject, this.transform.position.z - range, 1.0f).setEase(typeEase).setOnComplete(Move0).setDelay(1.0f);
                break;
            case Move.HORIZONTAL:
                LeanTween.moveX(this.gameObject, this.transform.position.x - range, 1.0f).setEase(typeEase).setOnComplete(Move0).setDelay(1.0f);
                break;
            default:
                break;
        }
    }
}
