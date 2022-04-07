using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    /*Creation de cette atribut afin de recuper l'objet zone de fruit et des autres icons 
     */
    public BoxCollider2D gridArea;
    public SpriteRenderer bonuscicon;
    

    /*
     * Methode appeller automatiquement au lancement sert a appeller la methode qui fait apparaitre le bonus
     * La fonction showBonus commence aprés 5 secondes de debut et est appellé toute les 10 secondes
     */
    void Start()
    {
       
        InvokeRepeating("showBonus", 5f,10f);

    }
    /*
     * Fonction qui cache le fruit
     */
    private void hideBonus()
    {
        bonuscicon.enabled = false;
    }
    /*
     * Fonction qui affiche le bonus
     */
    private void showBonus()
    {
        bonuscicon.enabled = true;
        RandomePosition();

    }



    /*Methode qui sert a generer une position aleatoire dans la limite de la zone ici bounds max et min
    */
    private void RandomePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

    }

    /*Cette methode permet de determiner quoi fair quand le snake entre en collision avec un fruit
    *Ici la verification permet de verifier si cest bien le snake
    *Ici le fruit est caché
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SnakeHead")
        {
            hideBonus();
        }

        if(other.tag == "Fruit")
        {
            RandomePosition();
        }
    }
}
