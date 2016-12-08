在iOS 9之前我们可以使用UIAlertView来显示一个弹出框

```objc
//创建弹出框
UIAlertView *alertView = [[UIAlertView alloc]
                           initWithTitle:@"DefaultStyle" 
                           message:@"the default alert view style"
                           delegate:self 
                           cancelButtonTitle:@"Cancel" 
                           otherButtonTitles:@"OK", nil];
//显示弹出框
[alertView show];
```

UIAlertView在iOS 9之后被弃用了，使用UIAlertController来显示弹出框
```objc
//弹出框标题和内容
AlertController *alertController = [UIAlertController
                              alertControllerWithTitle:alertTitle
                              message:alertMessage
                              preferredStyle:UIAlertControllerStyleAlert];
//添加按钮及事件
UIAlertAction *cancelAction = [UIAlertAction 
            actionWithTitle:NSLocalizedString(@"Cancel", @"Cancel action")
                      style:UIAlertActionStyleCancel
                    handler:^(UIAlertAction *action)
                    {
                      NSLog(@"Cancel action");
                    }];

UIAlertAction *okAction = [UIAlertAction 
            actionWithTitle:NSLocalizedString(@"OK", @"OK action")
                      style:UIAlertActionStyleDefault
                    handler:^(UIAlertAction *action)
                    {
                      NSLog(@"OK action");
                    }];
//添加按钮到弹出框
[alertController addAction:cancelAction];
[alertController addAction:okAction];
//显示弹出框
[self presentViewController:alertController animated:YES completion:nil];
```
还可以在里面添加文本框
```objc
[alertController addTextFieldWithConfigurationHandler:^(UITextField *textField)
 {
   textField.placeholder = NSLocalizedString(@"LoginPlaceholder", @"Login");
 }];

[alertController addTextFieldWithConfigurationHandler:^(UITextField *textField)
 {
   textField.placeholder = NSLocalizedString(@"PasswordPlaceholder", @"Password");
   textField.secureTextEntry = YES;
 }];
 ```
 在OK按钮按下后获取文本框中的内容
 ```objc
 UIAlertAction *okAction = [UIAlertAction
  actionWithTitle:NSLocalizedString(@"OK", @"OK action")
  style:UIAlertActionStyleDefault
  handler:^(UIAlertAction *action)
  {
    UITextField *login = alertController.textFields.firstObject;
    UITextField *password = alertController.textFields.lastObject;
    ...
  }];
  ```

  **参考**

  [UIAlertController Changes in iOS 8](http://useyourloaf.com/blog/uialertcontroller-changes-in-ios-8/)

