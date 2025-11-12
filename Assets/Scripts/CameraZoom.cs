using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Transform target;//追従対象
    [SerializeField] private float offsetY = 2f;//スプライト+余裕
    [SerializeField] private float smooth = 2f;//カメラ追従の滑らかさ

    [SerializeField] private float baseSize = 5f;//基本カメラサイズ
    [SerializeField] private float zoomSpeed = 0.05f;//高度に応じたズーム速度
    [SerializeField] private float maxZoom = 15f;//ズームの上限

    private Camera cam;
    private float maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
        maxY = target.position.y;   
    }

    void LateUpdate()
    {
        if (target == null) return;

        // --- 高さに応じて追従 ---
        Vector3 newPos = transform.position;
        newPos.y = Mathf.Lerp(transform.position.y, target.position.y + offsetY, Time.deltaTime * smooth);
        transform.position = newPos;

        // --- 高さに応じてズームアウト ---
        if (target.position.y > maxY)
        {
            maxY = target.position.y;
        }

        float targetSize = baseSize + (maxY * zoomSpeed);
        targetSize = Mathf.Clamp(targetSize, baseSize, maxZoom);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * 2f);
    }
}
