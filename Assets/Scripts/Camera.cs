using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _target;
	[SerializeField] private float _speed;

	private Vector3 _position;

	private void Start()
	{
		_position = _target.InverseTransformPoint(transform.position);
	}

	private void LateUpdate()
	{
		Quaternion oldRotation = _target.rotation;
		_target.rotation = Quaternion.Euler(0, oldRotation.eulerAngles.y, 0);
		Vector3 currentPosition = _target.TransformPoint(_position);
		_target.rotation = oldRotation;
		
		transform.position = Vector3.Lerp(transform.position, currentPosition, _speed * Time.deltaTime);
		Quaternion currentRotation = Quaternion.LookRotation(_target.position - transform.position);
		transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, _speed * Time.deltaTime);
	}
}
