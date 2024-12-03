using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuEvents : MonoBehaviour
{
    public AudioSource audioPlayButton;
    public void PlayGame()
    {
        audioPlayButton.Play();
        Invoke("LoadGameScene", audioPlayButton.clip.length); // Espera a que termine el audio
    }
    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
        #else
            Application.Quit(); // Cierra la aplicación en compilación
        #endif
    }
}
