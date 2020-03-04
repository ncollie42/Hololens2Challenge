using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class WinLoss : MonoBehaviour
{
    [SerializeField] GameObject playerBase;
    [SerializeField] GameObject AIBase;
    [SerializeField] GameObject RestartButton;
    [SerializeField] TextMeshPro text;
    void Update()
    {
        if (playerBase.activeSelf && AIBase.activeSelf)
            return;
        text.text = (playerBase.activeSelf ? "You win" : "You Lost");
        Time.timeScale = 0.0f;
        RestartButton.SetActive(true);
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
