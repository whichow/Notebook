<div>

简单的上下左右手势识别

</div>

<div>

``` {.prettyprint .linenums .prettyprinted}
using UnityEngine;using System.Collections;using UnityEngine.Events;public class TouchSwape : MonoBehaviour {    public UnityEvent swapeLeft;    public UnityEvent swapeRight;    public UnityEvent swapeUp;    public UnityEvent swapeDown;    private Vector2 totalPosition;    void Update () {        if (Input.touchCount > 0) {            if (Input.GetTouch(0).phase == TouchPhase.Moved) {                totalPosition += Input.GetTouch (0).deltaPosition;                Debug.Log (totalPosition);            }            if (Input.GetTouch(0).phase == TouchPhase.Began) {                totalPosition = Vector2.zero;            }            if (Input.GetTouch(0).phase == TouchPhase.Ended) {                if (totalPosition.x > 100f) {                    swapeRight.Invoke ();                }                if (totalPosition.x < -100f) {                    swapeLeft.Invoke ();                }                if (totalPosition.y > 100f) {                    swapeUp.Invoke ();                }                if (totalPosition.y < -100f) {                    swapeDown.Invoke ();                }            }        }    }}
```

</div>

<div>

\

</div>
