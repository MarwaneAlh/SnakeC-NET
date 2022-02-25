using UnityEngine;

public class SnakeGameScript : MonoBehaviour
{

   /*Utilisation d'attribut de type Vector , type qui contient deux valeurs comme une paire
   /*Cette value va servire a stocker l'axe X ainsi que l'xe Y de la direction 
   /*Initialisation a la direction right
   */
   private Vector2 _direction = Vector2.right;

   /*Methode update qui va etre appellé en permance afin de gerer le jeux
   /*Check quelle touche du clavier entré , ici l'ont joue avec les fleches pour en changer la direction
   /*Possibilité de le changer en switch case(a ameliorer)
   */
   private void Update()
   {
      if(Input.GetKeyDown(KeyCode.UpArrow)){
         _direction=Vector2.up;
      }else if(Input.GetKeyDown(KeyCode.DownArrow)){
         _direction=Vector2.down;
      }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
         _direction=Vector2.left;
      }else if(Input.GetKeyDown(KeyCode.RightArrow)){
         _direction=Vector2.right;

   }
   }

   /*Creattion de cette methode afin d'etre appelé dans un laps de temps
   /*Acces a la propriété transform de l'objet afin de lajouter a la value direction
   /*La methode Mathf.Round permet d'arrondir la position 
   */
   private void FixedUpdate(){
      this.transform.position = new Vector3(
         Mathf.Round(this.transform.position.x)+_direction.x,
         Mathf.Round(this.transform.position.y)+_direction.y,
         0.0f
         );
   }
}
