using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActionHandler : MonoBehaviour
{
    [SerializeField] private Button button; // Кнопка в UI
    private IButtonAction buttonAction;    // Действие, которое будет выполняться

    // Устанавливаем действие для кнопки
    public void SetAction(IButtonAction action)
    {
        buttonAction = action;
    }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        buttonAction?.Execute(); // Выполняем действие при нажатии
    }
}
