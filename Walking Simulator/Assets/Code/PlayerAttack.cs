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

    public TextMeshProUGUI collectiblesCollected;

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

<<<<<<< Updated upstream
    public void onTriggerEnter(Collider other) {
        if (other.CompareTag("Collectible")) {
=======
    public void OnTriggerEnter(Collider other) {

        print("SUISSHYUSS!");
        if (other.tag == "Collectible")
        {
>>>>>>> Stashed changes
            AddScore(1);
            _audioSource.PlayOneShot(scoreUp);
            other.gameObject.SetActive(false);
        }
    }
    
    void AddScore(int points) {
        PublicVars.score += points;
        collectiblesCollected.text = "Battery Cells Collected: " + PublicVars.score;
    }
    
}
