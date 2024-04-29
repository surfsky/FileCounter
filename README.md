# FileCounter

- 源码统计及合并工具，可用于著作权申报
- 作者：https://www.github.com/surfsky/


# 功能

- 可统计各种文件的数目和代码行数
- 合并源码
- 可设置文本编码方式
- 可控制输出行数
- 可跳过连续空行
- 可跳过连续注释行


# 窗口方式运行

- 直接双击 FileMerger.exe
- 按照页面提示操作
![](https://github.com/surfsky/FileMerger/blob/master/Images/form.png)
         
# 控制台方式运行

```
FileMerger.exe  .\Test\  out.txt  9000
```

- 参数1：源代码目录
- 参数2：输出文件路径
- 参数3：输出文件行数
![](https://github.com/surfsky/FileMerger/blob/master/Images/console.png)


# Tasks

- 列出文件勾选后再导出，更可控
- 排序方式、深度优先、广度优先

# History

2.0
    - 更名为 FileCounter。
    - 类库迁移到 NetFramework 4.8。
    - 可跳过一些不需要统计的子目录。
    - 可跳过隐藏目录。
    - 修改导出后的文件名，用相对路径，并用注释行分隔。
    - 修改默认统计文件，跳过一些配置类的文件。
    - 优化目录和文件排序，并广度优先检索。

1.0
    - 可统计各种文件的数目和代码行数
    - 合并源码
    - 可设置文本编码方式
    - 可控制输出行数
    - 可跳过连续空行
    - 可跳过连续注释行
