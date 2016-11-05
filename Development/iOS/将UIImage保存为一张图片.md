// Create path.

NSArray \*paths =
NSSearchPathForDirectoriesInDomains(NSDocumentDirectory,
NSUserDomainMask, YES);

NSString \*filePath = \[\[paths objectAtIndex:0\]
stringByAppendingPathComponent:@"Image.png"\];

\

// Save image.

\[UIImagePNGRepresentation(image) writeToFile:filePath atomically:YES\];

\[UIImageJPGRepresentation(image) writeToFile:filePath atomically:YES\];
