﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Placeble : MonoBehaviour {
    protected float angle;
    protected int startHealth = 4;
    protected int health;
    protected GameObject dustPrefab;

    public virtual void GetHurt() {
        health--;
        InstantiateDust();
        if (health == 0) {
            Destroy(gameObject);
        }
    }

    private void InstantiateDust() {
        for (int i = 0; i < 5; i++) {
            Instantiate(dustPrefab, transform.position, Quaternion.identity);
        }
    }

    public virtual void Regenerate() {
        //if we add this to shields each round
        //if (health+1 > startHealth)
        //{
        //    return;
        //}
        health++;
    }

    protected Vector3 StickToPlanet(Vector2 parent, Transform self) {
        health = startHealth;
        float deltaX = parent.x - self.position.x;
        float deltaY = parent.y - self.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        return new Vector3(self.rotation.x, self.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI / 2)));
    }

}
