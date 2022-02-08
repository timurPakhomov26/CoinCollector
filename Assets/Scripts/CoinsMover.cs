
using UnityEngine;

public class CoinsMover : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    private Transform _moneyIcon;
    
    

    private void Start()
     { 
       _moneyIcon=GameObject.FindGameObjectWithTag("MoneyIcon").GetComponent<Transform>();    
     }
    
     private void Update()
      {
          transform.position = Vector3.MoveTowards(transform.position,
          _moneyIcon.transform.position,_speed*Time.deltaTime);
      }

    public void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("MoneyIcon"))
          {
               EventManager.SendEnemy();           
               Destroy(gameObject);
          }
    }

}
