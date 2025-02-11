using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // UI элемент для таймера
    [SerializeField] private float restartDelay = 5f; // Время до перезапуска
    private bool isCounting = false;
    private float timeLeft;

    public void StartCountdown()
    {
        if (isCounting) return; // Не запускать повторно
        isCounting = true;

        timeLeft = restartDelay; // Устанавливаем начальное значение
        timerText.text = Mathf.FloorToInt(timeLeft).ToString(); // Показываем стартовое число
        gameObject.SetActive(true); // Включаем объект (если он выключен)

        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            timerText.text = Mathf.FloorToInt(timeLeft).ToString(); // Обновляем UI
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезапуск сцены
    }
}
