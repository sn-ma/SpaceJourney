using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text text;
    private int initialTime = 0;

    public int GetScore()
    {
        return (int)Time.realtimeSinceStartup - initialTime;
    }

    void Start()
    {
        text = GetComponent<Text>();
        initialTime = (int) Time.realtimeSinceStartup;
    }

    void Update()
    {
        text.text = $"Score: {GetScore()}s";
    }
}
