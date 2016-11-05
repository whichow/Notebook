If you run into `IOError: decoder jpeg not available`{.prettyprint
.prettyprinted
style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"} when
trying to use PIL or Pillow you can generally resolve this by
uninstalling PIL/Pillow and then installing libjpeg-dev, finally
reinstalling PIL/Pillow

Debian/Ubuntu {#debianubuntu style="font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; line-height: 1.25; margin-top: 0.5rem; margin-bottom: 1rem; font-size: 16px; padding-top: 2rem; color: rgb(17, 17, 17); font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"}
-------------

1.  `pip uninstall Pillow`{.prettyprint .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"} or `pip uninstall PIL`{.prettyprint
    .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"}
2.  `sudo apt-get install libjpeg-dev`{.prettyprint .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"}
3.  `pip install Pillow`{.prettyprint .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"}

Redhat/CentOS {#redhatcentos style="font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; line-height: 1.25; margin-top: 0.5rem; margin-bottom: 1rem; font-size: 16px; padding-top: 2rem; color: rgb(17, 17, 17); font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"}
-------------

1.  `pip uninstall Pillow`{.prettyprint .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"} or `pip uninstall PIL`{.prettyprint
    .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"}
2.  `sudo yum install libjpeg-devel`{.prettyprint .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"}
3.  `pip install Pillow`{.prettyprint .prettyprinted
    style="font-family: Monaco, Consolas, monospace; font-size: inherit; background-color: transparent; border-radius: 3px;"}\
    <div style="color:gray">

    来源： <https://coderwall.com/p/faqccw/pil-pillow-ioerror-decoder-jpeg-not-available>

    </div>


