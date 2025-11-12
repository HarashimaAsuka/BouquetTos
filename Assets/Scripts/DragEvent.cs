using UnityEngine;
using UnityEngine.EventSystems;

public class DragEvent : MonoBehaviour
{
    Vector3 dragPos;
    Vector2 prevPos;
    [SerializeField] private float throwPower = 0.1f;

    public void OnPointerDown(BaseEventData data)
    {
        var p = data as PointerEventData;
        Vector3 mousePos = p.position;
        this.dragPos = Camera.main.WorldToScreenPoint(transform.position) - mousePos;
    }

    public void OnDrag(BaseEventData data)
    {
        var p = data as PointerEventData;
        this.prevPos = p.position;
        Vector3 mousePos = p.position;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos + this.dragPos);
    }

    public void OnPointerUp(BaseEventData data)
    {
        //マウスカーソルの移動量 -> 速度
        var p = data as PointerEventData;
        var d = p.position - this.prevPos;
        GetComponent<Rigidbody2D>().linearVelocity = d * throwPower;
    }
}