using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{   
   public int vidas;
   public int pontos;  
   public int high_score; 
   public int pup;
   public bool is_paused, is_pup_active;
   public delegate void ChangeStateDelegate();
   public static ChangeStateDelegate changeStateDelegate;
   private static GameManager _instance;

   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

    private GameManager()
   {
       vidas = 10;
       pontos = 0;
       high_score = 0;
       pup = 2;
       is_paused = false;
       is_pup_active = false;
   }

   public void TakeDamage(){
       vidas --;
   }

   public void Hit(){
       pontos++;
   }

   public void Restart(bool useStateDelagete){
        vidas = 10;
        pontos = 0;
        pup = 2;
        is_paused = false;
        if(useStateDelagete) changeStateDelegate();
   }

   public void TogglePause(){
       is_paused = !is_paused;
   }

   public bool ActivatePUP(){
       if(pup > 0 && !is_pup_active){
           is_pup_active = true;
           return true;
       }
       return false;
   }

   public void DeactivatePUP(){
        pup --;
        is_pup_active = false;
   }
}
