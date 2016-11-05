\

<span
style="font-family: sans-serif; font-size: inherit; font-style: inherit; font-variant: inherit; font-weight: inherit; line-height: inherit;">1.
atoi</span>\

<span style="font-family:sans-serif">int atoi ( const char \* str
);</span>

<span style="font-family:sans-serif">Convert string to integer</span>

<span style="font-family:sans-serif">Parses the C string str
interpreting its content as an integral number, which is returned as an
int value.</span>

<span style="font-family:sans-serif">/\* atoi example \*/</span>

<span style="font-family:sans-serif">\#include &lt;stdio.h&gt;</span>

<span style="font-family:sans-serif">\#include &lt;stdlib.h&gt;</span>

\

<span style="font-family:sans-serif">int main ()</span>

<span style="font-family:sans-serif">{</span>

<span style="font-family:sans-serif">  int i;</span>

<span style="font-family:sans-serif">  char szInput \[256\];</span>

<span style="font-family:sans-serif">  printf ("Enter a number:
");</span>

<span style="font-family:sans-serif">  fgets ( szInput, 256, stdin
);</span>

<span style="font-family:sans-serif">  i = atoi (szInput);</span>

<span style="font-family:sans-serif">  printf ("The value entered is %d.
The double is %d.\\n",i,i\*2);</span>

<span style="font-family:sans-serif">  return 0;</span>

<span style="font-family:sans-serif">}</span>

<span style="font-family:sans-serif">output</span>

<span style="font-family:sans-serif">Enter a number: 73</span>

<span style="font-family:sans-serif">The value entered is 73. The double
is 146.</span>

\

\

<span style="font-family:sans-serif">2. atol</span>

<span style="font-family:sans-serif">long int atol ( const char \* str
);</span>

<span style="font-family:sans-serif">Convert string to long
integer</span>

<span style="font-family:sans-serif">Parses the C string str
interpreting its content as an integral number, which is returned as a
long int value.</span>

<span style="font-family:sans-serif">/\* atol example \*/</span>

<span style="font-family:sans-serif">\#include &lt;stdio.h&gt;</span>

<span style="font-family:sans-serif">\#include &lt;stdlib.h&gt;</span>

\

<span style="font-family:sans-serif">int main ()</span>

<span style="font-family:sans-serif">{</span>

<span style="font-family:sans-serif">  long int li;</span>

<span style="font-family:sans-serif">  char szInput \[256\];</span>

<span style="font-family:sans-serif">  printf ("Enter a long number:
");</span>

<span style="font-family:sans-serif">  gets ( szInput );</span>

<span style="font-family:sans-serif">  li = atol (szInput);</span>

<span style="font-family:sans-serif">  printf ("The value entered is %d.
The double is %d.\\n",li,li\*2);</span>

<span style="font-family:sans-serif">  return 0;</span>

<span style="font-family:sans-serif">}</span>

<span style="font-family:sans-serif">output</span>

<span style="font-family:sans-serif">Enter a number: 567283</span>

<span style="font-family:sans-serif">The value entered is 567283. The
double is 1134566.</span>

\

\

<span style="font-family:sans-serif">3. atof</span>

<span style="font-family:sans-serif">double atof ( const char \* str
);</span>

<span style="font-family:sans-serif">Convert string to double</span>

<span style="font-family:sans-serif">Parses the C string str
interpreting its content as a floating point number and returns its
value as a double.</span>

\

<span style="font-family:sans-serif">/\* atof example: sine calculator
\*/</span>

<span style="font-family:sans-serif">\#include &lt;stdio.h&gt;</span>

<span style="font-family:sans-serif">\#include &lt;stdlib.h&gt;</span>

<span style="font-family:sans-serif">\#include &lt;math.h&gt;</span>

\

<span style="font-family:sans-serif">int main ()</span>

<span style="font-family:sans-serif">{</span>

<span style="font-family:sans-serif">  double n,m;</span>

<span style="font-family:sans-serif">  double pi=3.1415926535;</span>

<span style="font-family:sans-serif">  char szInput \[256\];</span>

<span style="font-family:sans-serif">  printf ( "Enter degrees: "
);</span>

<span style="font-family:sans-serif">  gets ( szInput );</span>

<span style="font-family:sans-serif">  n = atof ( szInput );</span>

<span style="font-family:sans-serif">  m = sin (n\*pi/180);</span>

<span style="font-family:sans-serif">  printf ( "The sine of %f degrees
is %f\\n" , n, m );</span>

<span style="font-family:sans-serif">  return 0;</span>

<span style="font-family:sans-serif">}</span>

\

<span style="font-family:sans-serif">Output</span>

<span style="font-family:sans-serif">Enter degrees: 45</span>

<span style="font-family:sans-serif">The sine of 45.000000 degrees is
0.707101</span>

\

\

<span style="font-family:sans-serif">4. itoa</span>

<span style="font-family:sans-serif">char \*  itoa ( int value, char \*
str, int base );</span>

<span style="font-family:sans-serif">Convert integer to string
(non-standard function)</span>

<span style="font-family:sans-serif">Converts an integer value to a
null-terminated string using the specified base and stores the result in
the array given by str parameter.</span>

<span style="font-family:sans-serif">This function is not defined in
ANSI-C and is not part of C++, but is supported by some
compilers.</span>

\

\

<span style="font-family:sans-serif">A standard-compliant alternative
for some cases may be sprintf:</span>

<span style="font-family:sans-serif">sprintf(str,"%d",value) converts to
decimal base.</span>

<span style="font-family:sans-serif">sprintf(str,"%x",value) converts to
hexadecimal base.</span>

<span style="font-family:sans-serif">sprintf(str,"%o",value) converts to
octal base</span>

\

<span style="font-family:sans-serif">/\* itoa example \*/</span>

<span style="font-family:sans-serif">\#include &lt;stdio.h&gt;</span>

<span style="font-family:sans-serif">\#include &lt;stdlib.h&gt;</span>

\

<span style="font-family:sans-serif">int main ()</span>

<span style="font-family:sans-serif">{</span>

<span style="font-family:sans-serif">  int i;</span>

<span style="font-family:sans-serif">  char buffer \[33\];</span>

<span style="font-family:sans-serif">  printf ("Enter a number:
");</span>

<span style="font-family:sans-serif">  scanf ("%d",&i);</span>

<span style="font-family:sans-serif">  itoa (i,buffer,10);</span>

<span style="font-family:sans-serif">  printf ("decimal:
%s\\n",buffer);</span>

<span style="font-family:sans-serif">  itoa (i,buffer,16);</span>

<span style="font-family:sans-serif">  printf ("hexadecimal:
%s\\n",buffer);</span>

<span style="font-family:sans-serif">  itoa (i,buffer,2);</span>

<span style="font-family:sans-serif">  printf ("binary:
%s\\n",buffer);</span>

<span style="font-family:sans-serif">  return 0;</span>

<span style="font-family:sans-serif">}</span>

<span style="font-family:sans-serif">Output</span>

<span style="font-family:sans-serif">Enter a number: 1750</span>

<span style="font-family:sans-serif">decimal: 1750</span>

<span style="font-family:sans-serif">hexadecimal: 6d6</span>

<span style="font-family:sans-serif">binary: 11011010110</span>

\

\

<span style="font-family:sans-serif">5. ftoa</span>

<span style="font-family:sans-serif"> \#include &lt;sstream&gt;</span>

\

<span style="font-family:sans-serif">string convertDouble(double value)
{</span>

<span style="font-family:sans-serif">  std::ostringstream o;</span>

<span style="font-family:sans-serif">  if (!(o &lt;&lt; value))</span>

<span style="font-family:sans-serif">    return "";</span>

<span style="font-family:sans-serif">  return o.str();</span>

<span style="font-family:sans-serif">}</span>
