using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    float speed;
    bool turning = false;

    void Start() {
        InitializeFlockSpeed();
    }

    void Update() {
        if (FlockManager.FM == null) {
            Debug.LogError("FlockManager.FM é nulo em Flock.Update(). Certifique-se de que o FlockManager está atribuído.");
            return;
        }

        Bounds b = new Bounds(Vector3.zero, FlockManager.FM.swimLimits * 2.0f);

        if (!b.Contains(transform.position)) {
            turning = true;
        } else {
            turning = false;
        }

        if (turning) {
            Vector3 direction = FlockManager.FM.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                FlockManager.FM.rotationSpeed * Time.deltaTime);
        } else {
            if (Random.Range(0, 100) < 10) {
                InitializeFlockSpeed();
            }

            if (Random.Range(0, 100) < 10) {
                ApplyRules();
            }
        }

        this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

    void InitializeFlockSpeed() {
        if (FlockManager.FM != null) {
            speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
        } else {
            Debug.LogError("FlockManager.FM é nulo em Flock.InitializeFlockSpeed(). Certifique-se de que o FlockManager está atribuído.");
        }
    }

    void ApplyRules() {
        // ... (o restante do seu código ApplyRules permanece o mesmo)
    }
}
