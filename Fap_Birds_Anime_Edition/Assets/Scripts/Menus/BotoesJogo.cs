using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    /// <summary>
    /// Script responsavel por dar função aos botões dos menus.
    /// </summary>
    public class BotoesJogo : MonoBehaviour {

        /// <summary>
        /// Função que vai para a cena do jogo.
        /// </summary>
        public void Jogar()
        {
            SceneManager.LoadScene("Jogo");
        }

        /// <summary>
        /// Função que vai para a cena do menu.
        /// </summary>
        public void Menu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
