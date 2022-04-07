using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonScript : MonoBehaviour
{

    /*Creation de cette atribut afin de recuper l'objet zone de fruit et des autres icons 
     */
    public BoxCollider2D gridArea;
    public SpriteRenderer poisonicon;

    /*
     * Methode appeller automatiquement au lancement sert a appeller la methode qui fait apparaitre le poison
     * La fonction showPoison commence aprés 7 secondes de debut et est appellé toute les 6 secondes
     */
    void Start()
    {

        InvokeRepeating("showPoison", 7f, 6f);

    }
    
    /*
     * Fonction qui affiche le poison
     */
    private void showPoison()
    {
        poisonicon.enabled = true;
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


}
