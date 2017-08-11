nginx

在nginx.conf的http块中加入
```
client_max_body_size 64M;
```
php-fpm

在php.ini中修改
```
upload_max_filesize = 64M
post_max_size = 64M
max_file_uploads = 120
max_execution_time = 300
```

在上传文件的时候如果出现“HTTP错误”，可以修改

nginx.conf
```
client_max_body_siz 64M;
```
wp-config.php
```
define('WP_MEMORY_LIMIT', '64MB');
```

[How to increase upload file size limit for Wordpress running on PHP-FPM and Nginx](https://www.garron.me/en/linux/increase-upload-size-limit-nginx.html)

[WordPress 上传文件“HTTP错误”](https://talk.ninghao.net/t/wordpress-http/685)

[How to Fix HTTP Error When Uploading Images?](https://wordpress.stackexchange.com/questions/59763/how-to-fix-http-error-when-uploading-images)