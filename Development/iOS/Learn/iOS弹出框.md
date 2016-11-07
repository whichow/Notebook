在iOS 9之前我们可以使用UIAlertView来显示一个弹出框

``` prettyprint
UIAlertView *messageAlert = [[UIAlertView alloc] initWithTitle:@"Raw Selected" message:@"You have select the row" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
```

UIAlertView在iOS 9之后被弃用了，使用UIAlertController来显示弹出框


