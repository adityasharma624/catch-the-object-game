using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float powerUpSpeed = 10f;
    private float currentSpeed;

    private bool isPoweredUp = false;

    int score = 0;

    public Text scoreText;
    private void Start()
    {
        currentSpeed = normalSpeed;
        ScoreUpdate();
    }
    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * currentSpeed * Time.deltaTime);

        float clampX = Mathf.Clamp(transform.position.x, -7, 7f);
        transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallingObject"))
        {
            score++;
            Destroy(collision.gameObject);
            ScoreUpdate();
        }
        else if (collision.CompareTag("SpeedPowerUp"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(SpeedBoost());
        }
    }

    void ScoreUpdate()
    {
        scoreText.text = "Score: " + score;

    }

    IEnumerator SpeedBoost()
    {
        if (isPoweredUp) yield break;

        isPoweredUp = true;
        currentSpeed = powerUpSpeed;

        yield return new WaitForSeconds(5f);
        currentSpeed = normalSpeed;
        isPoweredUp = false;
    }
}
 