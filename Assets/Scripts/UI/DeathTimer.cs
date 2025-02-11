using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // UI ������� ��� �������
    [SerializeField] private float restartDelay = 5f; // ����� �� �����������
    private bool isCounting = false;
    private float timeLeft;

    public void StartCountdown()
    {
        if (isCounting) return; // �� ��������� ��������
        isCounting = true;

        timeLeft = restartDelay; // ������������� ��������� ��������
        timerText.text = Mathf.FloorToInt(timeLeft).ToString(); // ���������� ��������� �����
        gameObject.SetActive(true); // �������� ������ (���� �� ��������)

        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            timerText.text = Mathf.FloorToInt(timeLeft).ToString(); // ��������� UI
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���������� �����
    }
}
