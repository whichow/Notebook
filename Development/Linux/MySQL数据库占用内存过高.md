最近搭了个网站玩一下，随着内容越来越多，MySQL经常出现问题，经过研究发现，MySQL占用了非常多的内存，导致内存爆掉，需要重启服务器
网上说的是因为MySQL为了增强性能开了缓冲功能，而且缓存又设置的过大导致的

我们在/etc/my.cnf中可以看到MySQL的默认配置：
```
performance_schema_max_table_instances 12500
table_definition_cache 1400
table_open_cache 2000
```
我们将其改小一点：
```
performance_schema_max_table_instances=600
table_definition_cache=400
table_open_cache=256
```
重启MySQL后内存占用小了很多

如果不是很在意MySQL性能的话还可以直接将缓冲功能关掉：
```
performance_schema=OFF
```

[MySQL 内存占用过高分析](https://virusdefender.net/index.php/archives/471/)

[解决 MySQL 突然占用全部内存的问题](https://www.logcg.com/archives/1757.html)

[MySQL 5.6版本 Linux下内存占用过高的解决办法](http://todoright.com/2016/11/24/MySQL-5-6%E7%89%88%E6%9C%AC-Linux%E4%B8%8B%E5%86%85%E5%AD%98%E5%8D%A0%E7%94%A8%E8%BF%87%E9%AB%98%E7%9A%84%E8%A7%A3%E5%86%B3%E5%8A%9E%E6%B3%95/)