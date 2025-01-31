﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controladores;
using UnityEngine;

/// <summary>
/// Classe responsavel por controlar o comportamento dos canos.
/// </summary>
public class ControladorCano : MonoBehaviour
{
    /// <summary>
    /// Controlador da nossa cena.
    /// </summary>
    private ControladorJogo controlador;
    /// <summary>
    /// Se já pontuamos ou não esse cano.
    /// </summary>
    private bool pontuado = false;

    // Função que acontece quando iniciamos o script, ocorre apenas uma vez.
    void Start () {
        controlador = GameObject.Find("Controlador").GetComponent<ControladorJogo>();
        transform.position = new Vector3(transform.position.x, Random.Range(0.3f, 2.7f), transform.position.z);
        GetComponent<Rigidbody2D>().velocity = new Vector2(controlador.velocidadeCanos, 0);
    }

    // Função que acontece a cada frame.
    void Update () {
        // Quando estiver na posição -4.62 no eixo X e não tiver sido pontuado ainda.
	    if (this.transform.position.x < -4.62f && !pontuado)
	    {
            // Vamos definir que ja foi pontuado e pontuar.
            pontuado = true;
            controlador.GetComponent<ControladorPontos>().Pontuar();
            // Toca o som de pontuação.
            controlador.GetComponent<AudioSource>().Play();  
	    }
        // Quando estiver na posição -7, iremos destruir o objeto.
        if (this.transform.localPosition.x < -7.2f)
	    {
            GameObject.Destroy(this.gameObject);
	    }
        // Se o jogo ainda não tiver executando, vamos deixar o cano com velocidade zero.
	    if (!controlador.jogoIniciado)
	    {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}
}
