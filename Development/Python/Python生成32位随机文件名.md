```python
import os
''.join(map(lambda xx:(hex(ord(xx))[2:]),os.urandom(16)))
```