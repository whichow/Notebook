import os

for root, dirs, files in os.walk('Images'):

    for dir in dirs:

        fullPath = root + '\\\\' + dir    \#遍历所有文件夹

    for name in files:

        fullName = os.path.join(root, name)    \#遍历所有文件
