using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneAction : IButtonAction
{
    public void Execute()
    {
        // ������������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
