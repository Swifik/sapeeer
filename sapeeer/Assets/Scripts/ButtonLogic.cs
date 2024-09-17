using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    public GameObject bombPrefab; 

    private void OnMouseDown()
    {

        Destroy(gameObject);


        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);


        StartCoroutine(BombCountdown(bomb));
    }

    private IEnumerator BombCountdown(GameObject bomb)
    {

        yield return new WaitForSeconds(3f);


        bomb.GetComponent<BombScript>().Explode();


        GameManager.instance.GameOver();
    }
}

public class BombScript : MonoBehaviour
{
    public float explosionRadius = 5f; 
    public float explosionForce = 1000f; 

    public void Explode()
    {

        Collider[] objects = Physics.OverlapSphere(transform.position, explosionRadius);


        foreach (Collider objectCollider in objects)
        {
            objectCollider.GetComponent<Rigidbody>()?.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }


        Destroy(gameObject);
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {

        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}