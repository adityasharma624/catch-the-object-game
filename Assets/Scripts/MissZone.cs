using UnityEngine;
using UnityEngine.SceneManagement;
public class MissZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallingObject"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Game Over");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
