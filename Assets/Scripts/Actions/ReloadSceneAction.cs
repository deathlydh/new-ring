using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneAction : IButtonAction
{
    public void Execute()
    {
        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
