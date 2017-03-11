``` objc
- (void)animateWith:(NSString *)name imageCount:(NSString *)imageCount{    
    if (self.imageView.isAnimating) {       
        return;    
    }   
    NSMutableArray *images = [NSMutableArray alloc] init];   
    for (int i = 0; i < imageCount; i++)   {      
        NSString *imageName = [NSString stringWithFormat:@"%@_%02d.jpg", name, i];    
        //这种方式会将图片缓存起来，下次使用时直接从缓存中读取，图片很大或者过多时会消耗大量内存      
        //UIImage *image = [UIImage imageNamed:imageName];     
        //不缓存图片，直接从硬盘中加载       
        NSString *path = [NSBundle mainBundle] pathForResource:imageName ofType:nil];       
        UIImage *image = [UIImage imageWithContentOfFile:path];     [images addObject:image];   
    }   
    //添加动画图片    
    [self.imageView setAnimationImages:images];   
    //设置动画执行时间  
    [self.imageView setAnimationDuration:self.ImageView.animationImages.count * 0.1);    
    //设置动画执行次数  
    [self.imageView setAnimationRepeatCount:1];   
    //开始动画  
    [self.imageView startAnimating];    
    //动画执行完后清除数组    
    [self.imageView performSelector:@selector(setAnimationImages:) withObject:nil afterDelay:self.imageView.animationDuration];
}
```


