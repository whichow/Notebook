# iOS获取时间

```objc
    //获取系统当前时间
    NSDate *date = [[NSDate alloc] init];
    NSTimeInterval sec = [date timeIntervalSinceNow];
    NSDate *currentDate = [[NSDate alloc] initWithTimeIntervalSinceNow:sec];
```

```objc
    //格式化输出时间
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init ];
    [formatter setDateFormat:@"yyy-MM-dd HH:mm:ss"];
    NSString *dateString = [formatter stringFromDate:currentDate];  
```

```objc
    //通过格式化的字符串获取时间
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:@"yyyy-MM-dd HH:mm:ss"];
    NSDate *date = [formatter dateFromString:@"2015-11-11 07:10:00"];
```