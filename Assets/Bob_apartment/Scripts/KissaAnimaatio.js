#pragma strict

var maxSize = 2.0;
var minSize = 0.2;
var speed = 1.0;

function Update()
{
	var range = maxSize - minSize;
	transform.localScale.y = (Mathf.Sin(Time.time * speed) + 1.0) / 2.0 * range + minSize;
}