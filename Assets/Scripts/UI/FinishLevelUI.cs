using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class FinishLevelUI : MonoBehaviour
    {
        public GameObject finishLevelUI;
        
        public void RestartLevel()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneManager.LoadScene("Level1");
        }
        
        public void LoadMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
