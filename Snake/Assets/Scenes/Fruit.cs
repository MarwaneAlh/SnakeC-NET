using UnityEngine;

public class Fruit : MonoBehaviour
{
    /*Creation de cette atribut afin de recuper l'objet zone de fruit 
     */
    public BoxCollider2D gridArea;

    /*Methode appeller automatiquement au lancement sert a appeler la methode random 
     */
    private void Start()
    {
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
     */
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "SnakeHead")
        {

            RandomePosition();
        }
        }
}
