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

    public AudioClip killSound;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AddScore(0);
        killed = 0;
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
        EnemiesRemaining(0);  
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
                    enemy.GetComponent<BoxCollider>().enabled = false;
                    enemy.GetComponent<EnemyStandardMovement>().enabled = false;
                    EnemiesRemaining(1);
                    _audioSource.PlayOneShot(killSound);
                }
            }
        }
    }

    private void FixedUpdate() {
        RaycastHit hit;
         if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist) && (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("crewmateHead"))) {
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
        switch(SceneManager.GetActiveScene().name) {
            case "Level 1":
                PublicVars.level2 = true;
                break;
            case "Level 2":
                PublicVars.level3 = true;
                break;
        }
        if (enemies == killed) {
            SceneManager.LoadScene("Level Selector");
        }
    }
}
