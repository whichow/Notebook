<span class="s1">- (</span><span class="s2">UIImage</span><span
class="s1">\*)maskImage:(</span><span class="s2">UIImage</span><span
class="s1">\*)image withMask:(</span><span
class="s2">UIImage</span><span class="s1">\*)maskImage {</span>

<span class="s1">    </span><span class="s2">CGImageRef</span><span
class="s1"> maskRef = maskImage.</span><span
class="s2">CGImage</span><span class="s1">;</span>

<span class="s1">    </span>

<span class="s3">    </span><span class="s2">CGImageRef</span><span
class="s3"> mask = </span><span class="s1">CGImageMaskCreate</span><span
class="s3">(</span><span class="s1">CGImageGetWidth</span><span
class="s3">(maskRef), </span><span
class="s1">CGImageGetHeight</span><span class="s3">(maskRef),
</span><span class="s1">CGImageGetBitsPerComponent</span><span
class="s3">(maskRef), </span><span
class="s1">CGImageGetBitsPerPixel</span><span class="s3">(maskRef),
</span><span class="s1">CGImageGetBytesPerRow</span><span
class="s3">(maskRef), </span><span
class="s1">CGImageGetDataProvider</span><span class="s3">(maskRef),
</span><span class="s4">NULL</span><span class="s3">, </span><span
class="s4">false</span><span class="s3">);</span>

<span class="s1">    </span>

<span class="s1">    </span><span class="s2">CGImageRef</span><span
class="s1"> masked = </span><span
class="s5">CGImageCreateWithMask</span><span class="s1">(\[image
</span><span class="s5">CGImage</span><span class="s1">\], mask);</span>

<span class="s3">    </span><span class="s1">CGImageRelease</span><span
class="s3">(mask);</span>

<span class="s1">    </span><span class="s2">UIImage</span><span
class="s1"> \*maskedImage = \[</span><span
class="s2">UIImage</span><span class="s1"> </span><span
class="s5">imageWithCGImage</span><span class="s1">:masked\];</span>

<span class="s3">    </span><span class="s1">CGImageRelease</span><span
class="s3">(masked);</span>

<span class="s1">    </span><span class="s4">return</span><span
class="s1"> maskedImage;</span>

<span class="s1">}</span>
