using UnityEngine;
using UnityEngine.UI;

public class Hight : MonoBehaviour
{
    private float maxY = 0f;
    public float Score => maxY;

    [SerializeField] private Text scoreText;
    // [SerializeField] private HeightScore heightScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ゲーム開始時の高さ
        maxY = transform.position.y;   
    }

    // Update is called once per frame
    void Update()
    {
        float currentY = transform.position.y;

        //Yの最大値を更新
        if(currentY > maxY)
        {
            maxY = currentY;
            Debug.Log(maxY);
        }

        scoreText.text = "高度:" + maxY.ToString("F1").TrimEnd('0').TrimEnd('.');
    }
}
