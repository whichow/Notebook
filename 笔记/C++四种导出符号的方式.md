1. The [__declspec(dllexport)](https://docs.microsoft.com/en-us/cpp/cpp/dllexport-dllimport?view=vs-2017) keyword in the source code

2. An `EXPORTS` statement in a .DEF file

3. An [/EXPORT](https://docs.microsoft.com/en-us/cpp/build/reference/export-exports-a-function?view=vs-2017) specification in a LINK command

4. A [comment](https://docs.microsoft.com/en-us/cpp/preprocessor/comment-c-cpp?view=vs-2017) directive in the source code, of the form `#pragma comment(linker, "/export: definition ")`. The following example shows a #pragma comment directive before a function declaration, where `PlainFuncName` is the undecorated name, and `_PlainFuncName@4` is the decorated name of the function:

   C++Copy

   ```cpp
   #pragma comment(linker, "/export:PlainFuncName=_PlainFuncName@4")
   BOOL CALLBACK PlainFuncName( Things * lpParams)
   ```

