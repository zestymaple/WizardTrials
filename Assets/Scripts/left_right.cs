﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_right : MonoBehaviour
{
	public Transform target;
	public float dirNum;


	void Update()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 heading = target.position - transform.position;
		dirNum = AngleDir(transform.forward, heading, transform.up);
	}


	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
	{
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);

		if (dir > 0f)
		{
			return 1f;
		}
		else if (dir < 0f)
		{
			return -1f;
		}
		else
		{
			return 0f;
		}
	}
}
