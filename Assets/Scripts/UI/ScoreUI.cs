using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text _uiScore;
    int _score;
    private void OnEnable()
    {
        GameManager.OnScoreChanged += UpdateScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore(int newScore)
    {
        _score += newScore;
        _uiScore.text = $"{_score}";
        // Update the score display here
    }
}
