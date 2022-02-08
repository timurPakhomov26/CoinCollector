
using System;

public class EventManager 
{
   public static Action OnEnemyKilled;

   public static void SendEnemy(){
    OnEnemyKilled?.Invoke();
   }
  
   
}
