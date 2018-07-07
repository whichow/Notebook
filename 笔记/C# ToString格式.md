**数字格式：**

| 说明 | 示例     | 输出                  |               |
| ---- | -------- | --------------------- | ------------- |
| C    | 货币     | 2.5.ToString("C")     | ￥2.50        |
| D    | 十进制数 | 25.ToString("D5")     | 00025         |
| E    | 科学型   | 25000.ToString("E")   | 2.500000E+005 |
| F    | 固定点   | 25.ToString("F2")     | 25.00         |
| G    | 常规     | 2.5.ToString("G")     | 2.5           |
| N    | 数字     | 2500000.ToString("N") | 2,500,000.00  |
| X    | 十六进制 | 255.ToString("X")     | FF            |

**时间格式：**

| **格式**        | **输出**                                                     | **示例**                                                     |
| --------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| **年**          |                                                              |                                                              |
| y               | 7                                                            | string yy = DateTime.Now.ToString("y-MM")yy="7-05"           |
| yy              | 07                                                           | string yy = DateTime.Now.ToString("yy-MM")yy="07-05"         |
| yyy 或更多的 y  | 1984                                                         | string yy = DateTime.Now.ToString("yyyy");yy="2007"          |
| **月**          |                                                              |                                                              |
| M               | 5.                                                           | string mon = DateTime.Parse("1984-05-09")ToString("yyyy-M")mon = "1984-5" |
| MM              | 05.                                                          | string mon = DateTime.Parse("1984-05-09")ToString("M Ｍ ")mon = "05" |
| MMM             | 如果是中文版的操作系统，则会输出：五月 .如果是英文操作系统，则输入月份前三个字母的简写：May | string mon = DateTime.Parse("2006-07-01").ToString("MMM")英文版操作系统： Jul中文版操作系统：七月 |
| MMMM 或更多的Ｍ | 如果是中文版的操作系统，则会输出：五月 .如果是英文操作系统，则输入月份的全写 | string mon = DateTime.Parse("2006-07-01").ToString("MMM")英文版操作系统： July中文版操作系统：七月 |
| **日期或星期**  |                                                              |                                                              |
| d               | 9                                                            | string dd= DateTime.Parse("1984-05-09")ToString("d")dd= "9"  |
| dd              | 09                                                           | string dd= DateTime.Parse("1984-05-09")ToString("dd")dd= "09" |
| ddd             | 如果是中文版的操作系统，则会输出星期，如星期三。 .如果是英文操作系统，则输出星期的简写：如Wed | string dd = DateTime.Parse("2006-07-01").ToString("ddd")英文版操作系统： Wed中文版操作系统：星期三 |
| dddd 或更多的 d | 如果是中文版的操作系统，则会输出星期，如星期三。 .如果是英文操作系统，则输出星期：如Wednesday | string dd = DateTime.Parse("2006-07-01").ToString("dddd")英文版操作系统： Wednesday中文版操作系统：星期三 |
| **小时**        |                                                              |                                                              |
| h               | 小时范围： 1-12                                              | string hh = DateTime.Now.ToString(“h”);hh = 8                |
| hh 或更多的 h   | 小时范围： 1-12                                              | string hh = DateTime.Now.ToString(“hh”);hh = 08              |
| H               | 小时范围： 0-23                                              | string hh = DateTime.Now.ToString(“yyyy-H”);hh = 2006-8      |
| HH 或更多的 H   | 小时范围： 0-23                                              | string hh = DateTime.Now.ToString(“yyyy-HH”);hh = 2006-08string hh = DateTime.Pare(“2006-7-4 18:00:00”).ToString(“yyyy-HH”);hh = 2006-18 |
| **分钟**        |                                                              |                                                              |
| m               | 6                                                            | string mm = DateTime.Now.ToString("yyyy-MM-dd-m");mm = “2006-07-01-6”; |
| mm 或更多的 m   | 06                                                           | string mm = DateTime.Now.ToString("yyyy-MM-dd-mm");mm = “2006-07-01-06”; |
| **秒**          |                                                              |                                                              |
| s               | 6                                                            | string mm = DateTime.Now.ToString("yyyy-MM-dd-s");mm = “2006-07-01-6”; |
| ss 或更多的 s   | 06                                                           | string mm = DateTime.Now.ToString("yyyy-MM-dd-ss");mm = “2006-07-01-06”; |