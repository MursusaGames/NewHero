using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private Slider playerHealthSlider;

    [SerializeField] private GameObject pauseMenu;

    public void UpdateHealthUI(int playerHealth)
    {
        playerHealthText.text = $"{playerHealth}/100";
        playerHealthSlider.value = playerHealth / 100f;
    }

    public void OnPauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }
}
