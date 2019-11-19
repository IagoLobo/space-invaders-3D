using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static bool isGameOver = false;  // Variável para verificar se o jogo acabou ou não
    public static bool playerWon = false;   // Variável para verificar se o jogador venceu o ataque alienígina
    public GameObject GameOverCanvas;       // Canvas de derrota
    private bool hasCalledGameOver = false; // Variável para impedir que o update fique repetindo
    public Text GameOverText;               // Texto que aparece na tela de Game Over

    void Update()
    {
        // Se é game over e ainda não foi chamado, executa esse if uma vez
        if(isGameOver && !hasCalledGameOver)
        {
            if(playerWon)   GameOverText.text = "YOU WIN!"; // Troca o texto para fazer sentido com a vitória
            hasCalledGameOver = true;       // Recebe verdadeiro para não ser chamada mais vezes
            Time.timeScale = 0;             // Para o tempo do jogo, paralizando todos os movimentos de física
            GameOverCanvas.SetActive(true); // Ativa o canvas para selecionar as opções de menu
        }

        // Se entrar nesse if, é porque já está no menu de Game Over
        if(isGameOver && hasCalledGameOver)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                isGameOver = false;                 // Reseta o estado do jogo
                Time.timeScale = 1;                 // Voltar o tempo, senão o jogo fica parado eternamente
                SceneManager.LoadScene("Gameplay"); // Reinicia a cena do jogo
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                isGameOver = false;     // Reseta o estado do jogo
                Time.timeScale = 1;     // Voltar o tempo, senão o jogo fica parado eternamente
                Application.Quit();     // Sai do jogo
            }
        }
    }
}
