using System.Collections;
using UnityEngine;

public class WinGameCutscene : MonoBehaviour
{
    [Header("Win Game Controller")]
    public bool endGame = false;

    [Header("Animator")]
    public Animator cameraAnim;
    public Animator bottomAnim;
    
    [Header("Scripts")]
    public PlayerController playerControllerScript;

    [Header("Game Object")]
    public GameObject creditsObject;
    public GameObject creditsMusic;

    void Update()
    {
        if(endGame) // se a chave que diz que o jogo acabou for verdadeira ele faz os negocio ai embaixo
        {
            playerControllerScript.canMove = false; // trava o movimento do player
            cameraAnim.SetTrigger("isEndGame"); // chama a animação da camera e limite do jogo
            bottomAnim.SetTrigger("isEndGame");
            creditsObject.SetActive(true);
            creditsMusic.SetActive(true);
        }
    }
}
