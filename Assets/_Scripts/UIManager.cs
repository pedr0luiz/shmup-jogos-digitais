using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
   public Text text_vidas, text_pontos, text_tempo, txt_pup;
   public GameObject pause_menu;
   float timer = 0;
   GameManager gm;
   void Start()
   {
       gm = GameManager.GetInstance();
   }
   
   void Update()
   {
       if(gm.is_paused){
           pause_menu.SetActive(true);
       } else{
           timer += Time.deltaTime;
           pause_menu.SetActive(false);
       }
       text_vidas.text = $"Vidas: {gm.vidas}";
       text_pontos.text = $"Pontos: {gm.pontos}";  
       text_tempo.text = $"{timer.ToString("F3")}s"; 
       txt_pup.text = $"Pups: {gm.pup}";
       if(gm.is_pup_active){
        txt_pup.color = new Color32(0, 255, 0, 255);   
       } else{
        txt_pup.color = new Color32(0, 0, 0, 255); 
       }
   }

   public void Retomar(){
       gm.TogglePause();
   }

   public void Recomecar(){
       timer = 0;
       gm.Restart(true);
   }
}
