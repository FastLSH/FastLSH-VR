// Copyright 2015 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GvrFPS : MonoBehaviour {
	//private const string DISPLAY_TEXT_FORMAT = "{0} msf\n({1} FPS\n x:{2} y:{3} z:{4})";
	private const string DISPLAY_TEXT_FORMAT = "x:{0} \ny:{1} \nz:{2}";
  private const string MSF_FORMAT = "#.#";
  private const float MS_PER_SEC = 1000f;

  private Text textField;
  private float fps = 60;

  public Camera cam;

  public Transform vrCamera;

  void Awake() {
    textField = GetComponent<Text>();
  }

  void Start() {
    if (cam == null) {
       cam = Camera.main;
    }

    if (cam != null) {
      // Tie this to the camera, and do not keep the local orientation.
      transform.SetParent(cam.GetComponent<Transform>(), true);
    }
  }

  void LateUpdate() {
    float deltaTime = Time.unscaledDeltaTime;
    float interp = deltaTime / (0.5f + deltaTime);
    float currentFPS = 1.0f / deltaTime;
    fps = Mathf.Lerp(fps, currentFPS, interp);
    float msf = MS_PER_SEC / fps;

		float x = vrCamera.position.x;	
		float y = vrCamera.position.y;	
		float z = vrCamera.position.z;	
 //   textField.text = string.Format(DISPLAY_TEXT_FORMAT,
 //       msf.ToString(MSF_FORMAT), Mathf.RoundToInt(fps));
		textField.text = string.Format(DISPLAY_TEXT_FORMAT,
			x.ToString("0.00"),y.ToString("0.00"),z.ToString("0.00"));


  }
}
