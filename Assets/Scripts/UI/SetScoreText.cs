using UnityEngine;
using UnityEngine.UI;

public class SetScoreText : MonoBehaviour
{
    void Start()
    {
        if (StaticValuesHolder.lastScore != 0L)
        {
            GetComponent<Text>().text = $"Game Over!\nYou survived for {StaticValuesHolder.lastScore} seconds!";
        }
    }
}
