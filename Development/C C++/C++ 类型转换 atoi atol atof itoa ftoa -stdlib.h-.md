1. atoi

int atoi ( const char \* str );

Convert string to integer

Parses the C string str interpreting its content as an integral number, which is returned as an int value.

/\* atoi example \*/

\#include &lt;stdio.h&gt;

\#include &lt;stdlib.h&gt;

int main ()

{

  int i;

  char szInput \[256\];

  printf ("Enter a number: ");

  fgets ( szInput, 256, stdin );

  i = atoi (szInput);

  printf ("The value entered is %d. The double is %d.\\n",i,i\*2);

  return 0;

}

output

Enter a number: 73

The value entered is 73. The double is 146.

2. atol

long int atol ( const char \* str );

Convert string to long integer

Parses the C string str interpreting its content as an integral number, which is returned as a long int value.

/\* atol example \*/

\#include &lt;stdio.h&gt;

\#include &lt;stdlib.h&gt;

int main ()

{

  long int li;

  char szInput \[256\];

  printf ("Enter a long number: ");

  gets ( szInput );

  li = atol (szInput);

  printf ("The value entered is %d. The double is %d.\\n",li,li\*2);

  return 0;

}

output

Enter a number: 567283

The value entered is 567283. The double is 1134566.

3. atof

double atof ( const char \* str );

Convert string to double

Parses the C string str interpreting its content as a floating point number and returns its value as a double.

/\* atof example: sine calculator \*/

\#include &lt;stdio.h&gt;

\#include &lt;stdlib.h&gt;

\#include &lt;math.h&gt;

int main ()

{

  double n,m;

  double pi=3.1415926535;

  char szInput \[256\];

  printf ( "Enter degrees: " );

  gets ( szInput );

  n = atof ( szInput );

  m = sin (n\*pi/180);

  printf ( "The sine of %f degrees is %f\\n" , n, m );

  return 0;

}

Output

Enter degrees: 45

The sine of 45.000000 degrees is 0.707101

4. itoa

char \*  itoa ( int value, char \* str, int base );

Convert integer to string (non-standard function)

Converts an integer value to a null-terminated string using the specified base and stores the result in the array given by str parameter.

This function is not defined in ANSI-C and is not part of C++, but is supported by some compilers.

A standard-compliant alternative for some cases may be sprintf:

sprintf(str,"%d",value) converts to decimal base.

sprintf(str,"%x",value) converts to hexadecimal base.

sprintf(str,"%o",value) converts to octal base

/\* itoa example \*/

\#include &lt;stdio.h&gt;

\#include &lt;stdlib.h&gt;

int main ()

{

  int i;

  char buffer \[33\];

  printf ("Enter a number: ");

  scanf ("%d",&i);

  itoa (i,buffer,10);

  printf ("decimal: %s\\n",buffer);

  itoa (i,buffer,16);

  printf ("hexadecimal: %s\\n",buffer);

  itoa (i,buffer,2);

  printf ("binary: %s\\n",buffer);

  return 0;

}

Output

Enter a number: 1750

decimal: 1750

hexadecimal: 6d6

binary: 11011010110

5. ftoa

 \#include &lt;sstream&gt;

string convertDouble(double value) {

  std::ostringstream o;

  if (!(o &lt;&lt; value))

    return "";

  return o.str();

}
