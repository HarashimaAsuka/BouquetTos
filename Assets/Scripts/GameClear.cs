using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public GameObject top;
    public GameObject floor;

    [SerializeField] private GameObject ClearCanvas;
    [SerializeField] private Text clearText;
    [SerializeField] private Text numText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numText.enabled = false;
        clearText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == top)
        {
        Debug.Log("Top に当たった！");
            ClearCanvas.SetActive(true);
            clearText.enabled = true;
        }
        else if (collision.gameObject == floor)
        {
        Debug.Log("Floor に当たった！");
            ClearCanvas.SetActive(true);
            numText.enabled = true;
        }
    }
}
