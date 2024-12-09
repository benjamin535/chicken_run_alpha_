using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCameraFollow : MonoBehaviour {

    public Transform chickenTransform; // Renamed from carTransform to chickenTransform
    [Range(1, 10)]
    public float followSpeed = 2;
    [Range(1, 10)]
    public float lookSpeed = 5;
    Vector3 initialCameraPosition;
    Vector3 initialChickenPosition;
    Vector3 absoluteInitCameraPosition;

    void Start() {
        initialCameraPosition = gameObject.transform.position;
        initialChickenPosition = chickenTransform.position;
        absoluteInitCameraPosition = initialCameraPosition - initialChickenPosition;
    }

    void FixedUpdate() {
        // Look at chicken
        Vector3 _lookDirection = (new Vector3(chickenTransform.position.x, chickenTransform.position.y, chickenTransform.position.z)) - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

        // Move to chicken
        Vector3 _targetPos = absoluteInitCameraPosition + chickenTransform.position;
        transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }
}
