<div>

import os

</div>

<div>

for root, dirs, files in os.walk('Images'):

</div>

<div>

    for dir in dirs:

</div>

<div>

        fullPath = root + '\\\\' + dir<span style="line-height: 1.6;"> 
  \#遍历所有文件夹</span>

</div>

<div>

    for name in files:

</div>

<div>

        fullName = os.path.join(root, name)<span
style="line-height: 1.6;">    \#遍历所有文件</span>

</div>
