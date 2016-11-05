Unity使用SerialPort
<div>

<div>

需要从.net 2.0 subset换成.net 2.0

</div>

<div>

要使用serialPort.ReadLine();

</div>

<div>

需要在前面加上

</div>

<div>

serialPort.NewLine = "\\n";

</div>

</div>
