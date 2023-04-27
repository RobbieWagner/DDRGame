using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlunderStatistics : MonoBehaviour
{
    int score;
    int streak;

    int perfects, excellents, greats, nices, misses;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI accuracyText;
    [SerializeField] TextMeshProUGUI streakText;

    [SerializeField] Color[] accuracyColors;

    enum Accuracy {Perfect, Excellent, Great, Nice, Miss}

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        streak = 0;

        perfects = 0;
        excellents = 0;
        greats = 0;
        nices = 0;
        misses = 0;

        scoreText.text = "Score: 0";
        accuracyText.text = "";
    }

    public void ChangeStatistics(int accuracy)
    {
        if(accuracy == (int) Accuracy.Perfect)
        {
            perfects++;
            streak++;

            score += streak * 2 + 100;
            accuracyText.text = "PERFECT";
            accuracyText.color = accuracyColors[(int) Accuracy.Perfect];
        }
        else if(accuracy == (int) Accuracy.Excellent)
        {  
            excellents++;
            streak++;

            score += streak + 75;
            accuracyText.text = "EXCELLENT";
            accuracyText.color = accuracyColors[(int) Accuracy.Excellent];
        }
        else if(accuracy == (int) Accuracy.Great)
        {
            greats++;
            streak++;

            score += streak + 50;
            accuracyText.text = "GREAT";
            accuracyText.color = accuracyColors[(int) Accuracy.Great];
        }
        else if(accuracy == (int) Accuracy.Nice)
        {
            nices++;
            streak++;

            score += streak + 25;
            accuracyText.text = "NICE";
            accuracyText.color = accuracyColors[(int) Accuracy.Nice];
        }
        else if(accuracy == (int) Accuracy.Miss)
        {
            misses++;
            streak = 0;

            accuracyText.text = "miss";
            accuracyText.color = accuracyColors[(int) Accuracy.Miss];
        }

        scoreText.text = "Score: " + score;
        streakText.text = "streak: " + streak;
    }
}
