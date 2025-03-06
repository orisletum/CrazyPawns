using System;
using UniRx;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    private readonly ReactiveProperty<bool> isDragging = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> IsDragging => isDragging;
    private readonly ReactiveProperty<Vector3> pawnPosition = new ReactiveProperty<Vector3>();
    public IReadOnlyReactiveProperty<Vector3> PawnPosition => pawnPosition;
    public static Action MouseDownAction;
    public static Action MouseUpAction;
    private Vector3 offset; 
    private float smoothSpeed = 10f;
 
    public void MouseDown(Vector3 _offset)
    {
        isDragging.Value = true;
        offset = _offset;   
    }

    public void MouseDrag(Vector3 point)
    {
        isDragging.Value = true;
        Vector3 newPosition = point + offset;
        pawnPosition.Value= newPosition;
        transform.position = newPosition;
        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothSpeed);
    }
    public void MouseUp()
    {
        isDragging.Value = false;
    }

}
