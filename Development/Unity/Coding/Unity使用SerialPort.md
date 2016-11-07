Unity使用SerialPort
需要从.net 2.0 subset换成.net 2.0

要使用serialPort.ReadLine();

需要在前面加上

serialPort.NewLine = "\\n";


