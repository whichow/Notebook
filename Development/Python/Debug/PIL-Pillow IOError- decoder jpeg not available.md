If you run into `IOError: decoder jpeg not available` when trying to use PIL or Pillow you can generally resolve this by uninstalling PIL/Pillow and then installing libjpeg-dev, finally reinstalling PIL/Pillow

Debian/Ubuntu
-------------

1.  `pip uninstall Pillow` or `pip uninstall PIL`
2.  `sudo apt-get install libjpeg-dev`
3.  `pip install Pillow`

Redhat/CentOS
-------------

1.  `pip uninstall Pillow` or `pip uninstall PIL`
2.  `sudo yum install libjpeg-devel`
3.  `pip install Pillow`
    来源： <https://coderwall.com/p/faqccw/pil-pillow-ioerror-decoder-jpeg-not-available>


