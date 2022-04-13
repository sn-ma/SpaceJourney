using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text text;
    private int initialTime = 0;

    public long GetScore()
    {
        return (long)Time.realtimeSinceStartup - initialTime;
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
