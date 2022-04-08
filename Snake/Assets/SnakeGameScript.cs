using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SnakeGameScript : MonoBehaviour
{
   
    


   /*Utilisation d'attribut de type Vector , type qui contient deux valeurs comme une paire
   /*Cette value va servire a stocker l'axe X ainsi que l'xe Y de la direction 
   /*Initialisation a la direction right
   *Latribut body ici represente son corps
   *Attribut Score ici representant le score
   *L'attribut AudioSource ici represente le fichier audio lorsqu'un joueur mange le fruit
   *L'attribut Text sert à fair une liaison avec le text UI 
   */
   private Vector2 _direction = Vector2.right;
   private List<Transform> _body;
    public Transform bodyPrefab;
    public static int score = 0;
    public AudioSource eatsounds;
    public Text textscore;

    /*Methode Game Over servant a generer l'ecran en cas de perte de jeux
     *
     */

  
    public void GameOver()
    {
       
        SceneManager.LoadScene("GameOverScene");
    }
    private void Start() 
    {
        textscore=GameObject.Find("Canvas/Text").GetComponent<Text>();
        _body = new List<Transform>();
        _body.Add(this.transform);  
    }

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
   *Ajout de la partie qui va coller le corps du serpent a sa tete dans la boucle for
    */
   private void FixedUpdate(){

        for(int i = _body.Count - 1; i > 0; i--)
        {
            _body[i].position = _body[i - 1].position;
        }
      this.transform.position = new Vector3(
         Mathf.Round(this.transform.position.x)+_direction.x,
         Mathf.Round(this.transform.position.y)+_direction.y,
         0.0f
         );
   }
    /*Methode creer pour gerer lagrandissement du serpent
     * Ici un objet transform créer sur unity est instancer 
     *La position est donnée grace au derniere element de la liste du body 
     */
    private void Grow() 
        
    {
        score += 10;
        Transform body = Instantiate(this.bodyPrefab);
        body.position = _body[_body.Count - 1].position;
        _body.Add(body);
    }

    /*Methode qui s'occupe du comportement a determiner l'orque le serpent entre en collision avec un mur du jeux ou son propre corps
     * Supression de tout les objets creer 
     * Suppresion des objets dans la liste du body
     * Reinitialisation a 0 du vector3
     * Appelle de la methode Game over afin de generer ecran de game over
     */

    private void ResetState()
        
    {
        
        
       GameOver();
        for (int i = 1; i < _body.Count;i++)
        {
            Destroy(_body[i].gameObject);
        }
        _body.Clear();
        _body.Add(this.transform);
        this.transform.position = Vector3.zero; 
    }

    /*Methode creer pour automatiquement ajouter de la longueru
     * au body du serpent quand il rentre en collisin avec un fruit
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Fruit")
        {
            Grow();
            Debug.Log("Score :  " +score);
            textscore.text = "Score : " + score;
            eatsounds.Play();
        }
        if (other.tag=="Bonus")
        {
            score += 50;
            textscore.text = "Score : " + score;
        }
        else if (other.tag == "Wall"||other.tag=="poison")
        {
          
            ResetState();   
        }
    }   

   
}
