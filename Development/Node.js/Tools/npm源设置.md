修改源地址为淘宝 NPM 镜像

```
npm config set registry http://registry.npm.taobao.org/
```

修改源地址为官方源

```
npm config set registry https://registry.npmjs.org/
```



除了手动设置外还可以使用nrm(NPM registry manager)来简单和快速切换源

安装

```
$ npm install -g nrm
```

查看可用源

```
$ nrm ls

* npm -----  https://registry.npmjs.org/
  cnpm ----  http://r.cnpmjs.org/
  taobao --  https://registry.npm.taobao.org/
  nj ------  https://registry.nodejitsu.com/
  rednpm -- http://registry.mirror.cqupt.edu.cn
  skimdb -- https://skimdb.npmjs.com/registry
```

选择源

```
$ nrm use cnpm  //switch registry to cnpm

    Registry has been set to: http://r.cnpmjs.org/
```



还可以使用cnpm代替npm

```
$ npm install -g cnpm --registry=https://registry.npm.taobao.org
```