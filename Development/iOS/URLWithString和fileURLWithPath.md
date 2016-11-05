URLWithString和fileURLWithPath
<div>

<div>

NSURL\* url = \[NSURL URLWithString:path\];     //生成的url没有file:

</div>

<div>

\

</div>

<div>

/Users/cgtiger/Library/Developer/CoreSimulator/Devices/AF656B39-8055-4E81-A33A-281622F507C8/data/Containers/Bundle/Application/C0D27BAE-2005-4890-9678-62348FF008BE/VideoFrameTest.app/pp.mp4

</div>

<div>

\

</div>

<div>

NSURL\* url = \[NSURL fileURLWithPath:path\];     //生成的url有file:

</div>

<div>

\

</div>

<div>

file:///Users/cgtiger/Library/Developer/CoreSimulator/Devices/AF656B39-8055-4E81-A33A-281622F507C8/data/Containers/Bundle/Application/C0D27BAE-2005-4890-9678-62348FF008BE/VideoFrameTest.app/pp.mp4

</div>

</div>
