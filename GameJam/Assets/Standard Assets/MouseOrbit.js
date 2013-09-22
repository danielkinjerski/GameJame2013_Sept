var rotJoy : GameObject;

var target : Transform;
var distance = 10.0;

var xSpeed = 250.0;
var ySpeed = 120.0;

/*var yMinLimit = -20;
var yMaxLimit = 80;*/

private var x = 0.0;
//private var y = 0.0;

@AddComponentMenu("Camera-Control/Mouse Orbit")
partial class MouseOrbit { }

function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    //y = angles.x;

	// Make the rigid body not change rotation
   	if (rigidbody)
		rigidbody.freezeRotation = true;
}

function LateUpdate () {
   
    		//x += Time.deltaTime * Input.GetAxis("Mouse X") * xSpeed;
    		//y -= Time.deltaTime * Input.GetAxis("Mouse Y") * ySpeed;
    		//y = ClampAngle(y, yMinLimit, yMaxLimit);
    	

        //var rotation = Quaternion.EulerAngles(/*y * Mathf.Deg2Rad*/35 * Mathf.Deg2Rad, x * Mathf.Deg2Rad, 0);
        var position = Vector3(0, -distance, 0) + target.position;
        
        transform.position = position;
    
}
