# 内购(In-App Purchase)详解

## 内购的种类

在iOS中内购分为一下几种类型：
- **消耗品** 在程序中仅供一次性使用的项目，可多次购买，不可恢复。如：金币，消耗类型的道具等。
- **非消耗品** 在用户的所有设备中可以无限期使用的项目，只能购买一次，可恢复。如：书籍，游戏关卡或程序的附加功能。
- **自动续订** 自动续订的产品像非消耗品一样在用户的所有设备可用上，不同的是，自动续订有过期时间。用户在订阅周期内可以访问已订阅的内容。当自动订阅将要过期时，系统将为用户自动续订。
- **非自动续订** 需要通过自己的服务器来同步和恢复购买，需要自己在 app 中计算订阅周期和检测过期时间，需要用户在每次订阅结束时续订，并且在订阅将要过期时提醒用户购买新的订阅。

>还有一种是**免费订阅**用来订阅报刊杂志的内容，需要使用到 iOS 中的报刊杂志功能，这里就不做介绍了。

## 获取产品列表

每种产品都有一个唯一的**产品标识符**。使用这些标识符来从 App Store 中获产品信息。可以从 app bundle 或者自己的服务器获取产品列表。

### 在 App Bundle 中嵌入产品 ID
在 app bundle 中创建一个 plist 文件包含一个产品标识符的数组，如下所示：
```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN"
 "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<array>
    <string>com.example.level1</string>
    <string>com.example.level2</string>
    <string>com.example.rocket_car</string>
</array>
</plist>
```
要从 plist 文件中获取产品列表，需要从 app bundle 中读取：
```objc
NSURL *url = [[NSBundle mainBundle] URLForResource:@"product_ids" withExtension:@"plist"];
NSArray *productIdentifiers = [NSArray arrayWithContentsOfURL:url];
```

### 从服务器中获取产品 ID
可以将产品列表的 JSON 文件存放在自己的服务器中：
```json
[
    "com.example.level1",
    "com.example.level2",
    "com.example.rocket_car"
]
```
从服务器中获取产品列表：
```objc
- (void)fetchProductIdentifiersFromURL:(NSURL *)url delegate:(id)delegate
{
    dispatch_queue_t global_queue =
           dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0);
    dispatch_async(global_queue, ^{
        NSError *err;
        NSData *jsonData = [NSData dataWithContentsOfURL:url
                                                  options:NULL
                                                    error:&err];
        if (!jsonData) { /* Handle the error */ }
 
        NSArray *productIdentifiers = [NSJSONSerialization
            JSONObjectWithData:jsonData options:NULL error:&err];
        if (!productIdentifiers) { /* Handle the error */ }
 
        dispatch_queue_t main_queue = dispatch_get_main_queue();
        dispatch_async(main_queue, ^{
           [delegate displayProducts:productIdentifiers]; // Custom method
        });
    });
}
```

## 获取产品信息

从 App Store 中获取产品信息，首先需要创建并用产品标识符列表初始化一个 `SKProductsRequest` 。需要对请求对象强引用，否则系统可能在请求完成之前就销毁了。委托对象必须实现 `SKProductsRequestDelegate` 来处理 App Store 的相应。
```objc
// Custom method
- (void)validateProductIdentifiers:(NSArray *)productIdentifiers
{
    SKProductsRequest *productsRequest = [[SKProductsRequest alloc]
                    initWithProductIdentifiers:[NSSet setWithArray:productIdentifiers]];
 
    // Keep a strong reference to the request.
    self.request = productsRequest;
    productsRequest.delegate = self;
    [productsRequest start];
}
 
// SKProductsRequestDelegate protocol method
- (void)productsRequest:(SKProductsRequest *)request
     didReceiveResponse:(SKProductsResponse *)response
{
    self.products = response.products;
 
    for (NSString *invalidIdentifier in response.invalidProductIdentifiers) {
        // Handle any invalid product identifiers.
    }
 
    [self displayStoreUI]; // Custom method
}
```
获取到产品的信息之后就可以将可购买的产品展示给用户了。如果返回的信息中包含无效的产品，可能是这个产品没有在 iTunes Connect 中正确的配置。注意不要将无效的产品展示给用户。

## 请求支付

### 创建支付请求
在用户选择了一个产品进行购买时，使用一个产品对象创建一个支付请求，可以设置购买的数量。产品对象是从之前的请求返回的产品列表中获取的。
```objc
SKProduct *product = <# Product returned by a products request #>;
SKMutablePayment *payment = [SKMutablePayment paymentWithProduct:product];
payment.quantity = 2;
```

### 提交支付请求
添加一个支付请求到支付队列中，支付队列会自动将它提交到 App Store。如果多次添加支付对象到队列中，支付队列将提交多次支付请求。
```objc
[[SKPaymentQueue defaultQueue] addPayment:payment];
```

## 等待 App Store 处理交易

交易队列在 App Store 和 Store Kit 中扮演一个中间角色。在提交一个支付请求到 App Store 后，当交易状态改变时，Store Kit 将调用 app 的 *交易队列观察者(transaction queue observer)*。观察者必须实现 `SKPaymentTransactionObserver` 协议。

在 app 启动时注册一个交易队列观察者，确保观察者可以在任何时候处理一个交易，而不仅仅在添加一个交易到队列之后。这样，如果你的 app 没有标记一个交易完成，Store Kit 将在 app 每次启动时调用观察者直到交易正确完成。
```objc
- (BOOL)application:(UIApplication *)application
 didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    /* ... */
 
    [[SKPaymentQueue defaultQueue] addTransactionObserver:observer];
}
```

在交易队列观察者中实现 `paymentQueue:updatedTransactions:` 方法，Store Kit 将在交易状态改变时调用这个方法。下面列出了所有的交易状态：

```objc
- (void)paymentQueue:(SKPaymentQueue *)queue
 updatedTransactions:(NSArray *)transactions
{
    for (SKPaymentTransaction *transaction in transactions) {
        switch (transaction.transactionState) {
            // Call the appropriate custom method for the transaction state.
            case SKPaymentTransactionStatePurchasing:
                [self showTransactionAsInProgress:transaction deferred:NO];
                break;
            case SKPaymentTransactionStateDeferred:
                [self showTransactionAsInProgress:transaction deferred:YES];
                break;
            case SKPaymentTransactionStateFailed:
                [self failedTransaction:transaction];
                break;
            case SKPaymentTransactionStatePurchased:
                [self completeTransaction:transaction];
                break;
            case SKPaymentTransactionStateRestored:
                [self restoreTransaction:transaction];
                break;
            default:
                // For debugging
                NSLog(@"Unexpected transaction state %@", @(transaction.transactionState));
                break;
        }
    }
}
```