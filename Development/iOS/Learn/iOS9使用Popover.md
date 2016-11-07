UIPopoverController在iOS 9之后被声明为废弃，统一使用UIViewController presentViewController来呈现Popover

``` prettyprint
//iOS 9之前UIPopoverController *pop = [[UIPopoverController alloc] initWithContentViewController:pvc];[pop presentPopoverFromBarButtonItem:firstItem permittedArrowDirections:UIPopoverArrowDirectionAny animated:YES];//iOS 9之后PopViewController *pvc = [[PopViewController alloc] init];pvc.modalPresentationStyle = UIModalPresentationPopover;pvc.popoverPresentationController.barButtonItem = firstItem;[self presentViewController:pvc animated:YES completion:nil];
```


