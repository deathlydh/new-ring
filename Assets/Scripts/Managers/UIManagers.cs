using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagers : MonoBehaviour
{
    [SerializeField] private ButtonActionHandler buttonActionHandler;

    private void Start()
    {
        // ������������� �������� ��� ������
        ReloadSceneAction reloadAction = new ReloadSceneAction();
        buttonActionHandler.SetAction(reloadAction);
    }
}
