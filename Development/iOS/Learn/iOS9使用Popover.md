UIPopoverController在iOS 9之后被声明为废弃，统一使用UIViewController presentViewController来呈现Popover

```objc
//iOS 9之前
UIPopoverController *pop = [[UIPopoverController alloc] initWithContentViewController:pvc];
[pop presentPopoverFromBarButtonItem:firstItem permittedArrowDirections:UIPopoverArrowDirectionAny animated:YES];
//iOS 9之后
PopViewController *pvc = [[PopViewController alloc] init];
pvc.modalPresentationStyle = UIModalPresentationPopover;
pvc.popoverPresentationController.barButtonItem = firstItem;
[self presentViewController:pvc animated:YES completion:nil];
```


