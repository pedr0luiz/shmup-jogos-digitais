using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScript : MonoBehaviour
{
   public Text text_score, text_high_score;
   GameManager gm;
   void Start()
   {
       gm = GameManager.GetInstance();
   }

   void Update(){
       if(gm.pontos > gm.high_score) gm.high_score = gm.pontos;
       text_score.text = $"Sua pontuação: {gm.pontos}";
       text_high_score.text = $"High score: {gm.high_score}";
   }

    public void Game(){
        SceneManager.LoadScene("Game");
        gm.Restart(false);
    }
}
