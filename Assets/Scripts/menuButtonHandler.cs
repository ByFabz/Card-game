using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtonHandler : MonoBehaviour
{
    public void startClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitClick() {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
