using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActionHandler : MonoBehaviour
{
    [SerializeField] private Button button; // ������ � UI
    private IButtonAction buttonAction;    // ��������, ������� ����� �����������

    // ������������� �������� ��� ������
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
        buttonAction?.Execute(); // ��������� �������� ��� �������
    }
}
