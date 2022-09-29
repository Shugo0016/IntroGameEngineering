using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    private float raycastDist = 50;

    public LayerMask enemyLayer;

    public Transform camTrans;

    public Image reticle;

    public TextMeshProUGUI collectiblesCollected;
    
    public TextMeshProUGUI enemiesRemaining;
    public int enemies;
    public int killed;

    private bool reticleTarget = false;

    AudioSource _audioSource;

    public AudioClip scoreUp;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AddScore(0);
        killed = 0;
        EnemiesRemaining(0);
        switch(SceneManager.GetActiveScene().name) {
            case "Level 1":
                enemies = PublicVars.Enemies1;
                break;
            case "Level 2":
                enemies = PublicVars.Enemies2;
                break;
            case "Level 3":
                enemies = PublicVars.Enemies3;
                break;
        }
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
    }

    private void FixedUpdate() {
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist) && (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Collectible"))) {
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
        if (other.CompareTag("Collectible")) {
            AddScore(1);
            _audioSource.PlayOneShot(scoreUp);
            Destroy(other.gameObject);
        }
    }
    
    void AddScore(int points) {
        PublicVars.score += points;
        collectiblesCollected.text = "Battery Cells Collected: " + PublicVars.score;
    }

    void EnemiesRemaining(int death) {
        killed += death;
        enemiesRemaining.text = "Enemies Remaining: " + (enemies - killed);
    }
}
