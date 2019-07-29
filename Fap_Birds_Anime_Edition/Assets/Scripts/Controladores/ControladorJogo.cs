using Assets.Scripts.Parallax;
using UnityEngine;

namespace Assets.Scripts.Controladores
{
    /// <summary>
    /// Classe que controla o jogo, como inicio, fim e sprites principais.
    /// </summary>
    public class ControladorJogo : MonoBehaviour
    {
        /// <summary>
        /// Booleano se o jogo ta executando ou não.
        /// </summary>
        public bool jogoIniciado;
        /// <summary>
        /// GameObject da tela inicial (com titulo Ready e mensagem para clicar no personagem).
        /// </summary>
        public GameObject inicial;

        /// <summary>
        /// GameObjects dos canos (Prefabs).
        /// </summary>
        public GameObject[] canos;
        /// <summary>
        /// GameObjects dos personagens (Prefabs).
        /// </summary>
        public GameObject[] personagens;
        /// <summary>
        /// GameObjects dos fundos com parallax.
        /// </summary>
        public GameObject[] fundos;
        /// <summary>
        /// Materiais para quando o período é de diurno.
        /// </summary>
        public Material[] dia;
        /// <summary>
        /// Materiais para quando o período é de noturno.
        /// </summary>
        public Material[] noite;
        /// <summary>
        /// Velocidade com que os canos vão se mover.
        /// </summary>
        public float velocidadeCanos = -2.0f;
        /// <summary>
        /// Qual período do dia será o fundo, dia ou noite.
        /// </summary>
        private int periodo;
        /// <summary>
        /// Obejto do cano atual (Se é o de periodo noturno ou diuno).
        /// </summary>
        private GameObject cano;


        // Função que ocorre uma vez, antes do Start, quando a cena é carregada.
        void Awake()
        {
            // Número aleatório, sendo 0 ou 1. 0 para diurno e 1 para noturno.
            periodo = Random.Range(0, 2);
            // O cano atual será o cano no indice correspondente ao período.
            //cano = canos[periodo];
            cano = canos[0];

            // Se for de noite.
            if (periodo == 1)
            {
                // Para todos os materiais de noite.
                for (int i = 0; i < noite.Length; i++)
                {
                    // Para cada fundo, adicionaremos o material correto.
                    fundos[i].GetComponent<Renderer>().material = noite[i];
                }

            }
            // Se for de dia.
            else
            {
                // Para todos os materiais de dia.
                for (int i = 0; i < dia.Length; i++)
                {
                    // Para cada fundo, adicionaremos o material correto.
                    fundos[i].GetComponent<Renderer>().material = dia[i];
                }

            }

            // Numero aleatorio para saber qual dos personagem usaremos na rodada (Amarelo, Azul ou Vermelho).
            int rand = Random.Range(0, personagens.Length);
            // Instanciar o personagem da rodada atual.
            //GameObject personagem = Instantiate(personagens[rand]);
            GameObject personagem = Instantiate(personagens[0]);
            // Definimos que o jogo não está sendo executado ainda.
            jogoIniciado = false;

        }

        /// <summary>
        /// Função para iniciar o jogo.
        /// </summary>
        public void IniciarJogo()
        {
            // Define no bool jogoIniciado que o jogo já se encontra executando.
            jogoIniciado = true;
            // Começa a invocar os canos, será repetido a cada um tempo aleatório entre 1.5 e 2 segundos.
            InvokeRepeating("InvocaCanos", 2f, Random.Range(1.5f, 2.0f));
            //personagens[0].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            // Define que o objeto de tela inicial será desativado, pois já começamos o jogo.
            inicial.SetActive(false);
            
        }

        /// <summary>
        /// Função para parar o jogo.
        /// </summary>
        public void PararJogo()
        {
            //personagens[0].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            // Define no bool jogoIniciado que o jogo não se encontra executando.
            jogoIniciado = false;
            // Para cada objeto de fundo.
            foreach (GameObject fundo in fundos)
            {
                // Iremos parar a velocidade com que ocorre o efeito de scroll.
                fundo.GetComponent<Rolar>().velocidade = 0f;
            }
            // Cancela as invocações de canos.
            CancelInvoke();
        }
        
        /// <summary>
        /// Função que invoca os canos.
        /// </summary>
        public void InvocaCanos()
        {
            // Instancia o cano.
            Instantiate(cano);
        }
    }
}
