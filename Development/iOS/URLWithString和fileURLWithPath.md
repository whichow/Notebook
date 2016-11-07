URLWithString和fileURLWithPath
NSURL\* url = \[NSURL URLWithString:path\];     //生成的url没有file:

/Users/cgtiger/Library/Developer/CoreSimulator/Devices/AF656B39-8055-4E81-A33A-281622F507C8/data/Containers/Bundle/Application/C0D27BAE-2005-4890-9678-62348FF008BE/VideoFrameTest.app/pp.mp4

NSURL\* url = \[NSURL fileURLWithPath:path\];     //生成的url有file:

file:///Users/cgtiger/Library/Developer/CoreSimulator/Devices/AF656B39-8055-4E81-A33A-281622F507C8/data/Containers/Bundle/Application/C0D27BAE-2005-4890-9678-62348FF008BE/VideoFrameTest.app/pp.mp4


