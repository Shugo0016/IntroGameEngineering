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

    public AudioClip scoreUp;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AddScore(0);        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            print(Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist, enemyLayer));
            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist, enemyLayer)) {
                GameObject enemy = hit.collider.gameObject;
                if (enemy.CompareTag("Enemy")) {
                    Destroy(enemy.transform.GetChild(1).gameObject);
                    var x = enemy.GetComponent<BoxCollider>().enabled = false;

                }
            }
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

        print("SUISSHYUSS!");
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
