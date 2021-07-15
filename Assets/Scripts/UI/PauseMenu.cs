using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject PauseMenuUI;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        private void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void LoadMenu()
        {
            GameIsPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Main Menu");
        }

        public void RestartLevel()
        {
            GameIsPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Level1");
        }
    }
}
