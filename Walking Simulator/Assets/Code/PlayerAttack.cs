using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    private float raycastDist = 50;

    public LayerMask enemyLayer;

    public Transform camTrans;

    public Image reticle;

    public TextMeshProUGUI scoreText;

    private bool reticleTarget = false;

    AudioSource _audioSource;
    
    public AudioSource footsteps;

    public AudioClip scoreUp;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //AddScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist, enemyLayer)) {
                GameObject enemy = hit.collider.gameObject;
                if (enemy.CompareTag("Enemy")) {
                    Rigidbody enemyRB = enemy.GetComponent<Rigidbody>();
                    enemyRB.AddForce(transform.forward * 800 + Vector3.up * 200);
                    enemyRB.AddTorque(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)));
                }
                
                else if (enemy.CompareTag("Target")) {

                }
            }
        }
        if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("d") || Input.GetKeyDown("s")) {
            footsteps.enabled = true;
        } else {
            footsteps.enabled = false;
        }
    }

    private void FixedUpdate() {
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist) && (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Interactable"))) {
            if (!reticleTarget) {
                reticle.color = Color.red;
                reticleTarget = true;
            }
        } else if (reticleTarget) {
            reticle.color = Color.white;
            reticleTarget = false;
        }
    }

    public void onTriggerEnter(Collider other) {
        /*
        if (other.CompareTag("Enemy")) {
            AddScore(10);
            _audioSource.PlayOneShot(scoreUp);
            Destroy(other.gameObject);
        }
        */
    }
    /*
    void AddScore(int points) {
        PublicVars.score += points;
        scoreText.text = "Score: " + PublicVars.score;
    }
    */
}
